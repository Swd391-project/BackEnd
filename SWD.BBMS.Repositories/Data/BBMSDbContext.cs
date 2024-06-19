
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using SWD.BBMS.Repositories.Entities;

namespace SWD.BBMS.Repositories.Data
{
    public partial class BBMSDbContext : IdentityDbContext<User>
    {
        public BBMSDbContext()
        {
        }

        public BBMSDbContext(DbContextOptions<BBMSDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=ep-round-mouse-a1tew6z0-pooler.ap-southeast-1.aws.neon.tech; Database=bbms; Username=default; Password=UfGsaI7yBe5o");

        private string GetConnectionString()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true).Build();
            return configuration["ConnectionStrings:BBMSDB"];
        }

        public DbSet<Court> Courts { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<CourtGroup> CourtGroups { get; set;}

        public DbSet<Company> Companies { get; set; }

        public DbSet<Withdraw> Withdraws { get; set; }

        public DbSet<CourtSlot> CourtSlots { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<BookingDetail> BookingDetails { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        public DbSet<ContactPoint> ContactPoints { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<FlexibleBooking> FlexibleBookings { get; set; }

        public DbSet<Price> Prices { get; set; }

        public DbSet<BookingType> BookingTypes { get; set; }

        public DbSet<WeekdayActivity> WeekdayActivities { get; set; }

        public DbSet<CourtGroupActivity> CourtGroupActivities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "Staff",
                    NormalizedName = "STAFF"
                },
                new IdentityRole
                {
                    Name = "Manager",
                    NormalizedName = "MANAGER"
                },
                new IdentityRole
                {
                    Name = "Customer",
                    NormalizedName = "CUSTOMER"
                }
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);


            var hasher = new PasswordHasher<User>();
            User user = new User
            {
                Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                FullName = "System Admin",
                UserName = "admin@bbms.com",
                NormalizedUserName = "ADMIN@BBMS.COM",
                Role = "Admin",
                Email = "admin@bbms.com",
                Status = UserStatus.Active,
                PhoneNumber = "1234567890",
                PasswordHash = hasher.HashPassword(null, "Admin@123"),
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow
            };

            modelBuilder.Entity<User>().HasData(user);
            
            modelBuilder.Entity<Booking>()
            .HasOne(b => b.Payment)
            .WithOne(p => p.Booking)
            .HasForeignKey<Payment>(p => p.BookingId);
            modelBuilder.Entity<Payment>()
                .HasIndex(p => p.BookingId)
                .IsUnique();

            modelBuilder.Entity<User>()
                .Property(u => u.CreatedDate)
                //.HasColumnType("datetime")
                .HasDefaultValueSql("NOW() AT TIME ZONE 'UTC'");
            modelBuilder.Entity<User>()
                .Property(u => u.ModifiedDate)
                //.HasColumnType("datetime")
                .HasDefaultValueSql("NOW() AT TIME ZONE 'UTC'");

            modelBuilder.Entity<Booking>()
                .Property(u => u.CreatedDate)
                //.HasColumnType("datetime")
                .HasDefaultValueSql("NOW() AT TIME ZONE 'UTC'");
            modelBuilder.Entity<Booking>()
                .Property(u => u.ModifiedDate)
                //.HasColumnType("datetime")
                .HasDefaultValueSql("NOW() AT TIME ZONE 'UTC'");

            modelBuilder.Entity<Court>()
                .Property(u => u.CreatedDate)
                //.HasColumnType("datetime")
                .HasDefaultValueSql("NOW() AT TIME ZONE 'UTC'");
            modelBuilder.Entity<Court>()
                .Property(u => u.ModifiedDate)
                //.HasColumnType("datetime")
                .HasDefaultValueSql("NOW() AT TIME ZONE 'UTC'");

            modelBuilder.Entity<CourtGroup>()
                .Property(u => u.CreatedDate)
                //.HasColumnType("datetime")
                .HasDefaultValueSql("NOW() AT TIME ZONE 'UTC'");
            modelBuilder.Entity<CourtGroup>()
                .Property(u => u.ModifiedDate)
                //.HasColumnType("datetime")
                .HasDefaultValueSql("NOW() AT TIME ZONE 'UTC'");

            modelBuilder.Entity<BookingType>()
                .Property(u => u.CreatedDate)
                //.HasColumnType("datetime")
                .HasDefaultValueSql("NOW() AT TIME ZONE 'UTC'");
            modelBuilder.Entity<BookingType>()
                .Property(u => u.ModifiedDate)
                //.HasColumnType("datetime")
                .HasDefaultValueSql("NOW() AT TIME ZONE 'UTC'");

            modelBuilder.Entity<CourtSlot>()
                .Property(u => u.CreatedDate)
                //.HasColumnType("datetime")
                .HasDefaultValueSql("NOW() AT TIME ZONE 'UTC'");
            modelBuilder.Entity<CourtSlot>()
                .Property(u => u.ModifiedDate)
                //.HasColumnType("datetime")
                .HasDefaultValueSql("NOW() AT TIME ZONE 'UTC'");

            modelBuilder.Entity<CourtGroupActivity>()
                .HasKey(cga => new {cga.CourtGroupId, cga.WeekdayActivityId});
            modelBuilder.Entity<CourtGroupActivity>()
                .HasOne(cga => cga.CourtGroup)
                .WithMany(cg => cg.CourtGroupActivities)
                .HasForeignKey(cga => cga.CourtGroupId);
            modelBuilder.Entity<CourtGroupActivity>()
                .HasOne(cga => cga.WeekdayActivity)
                .WithMany(wa => wa.CourtGroupActivities)
                .HasForeignKey(cga => cga.WeekdayActivityId);

            modelBuilder.Entity<CourtGroup>()
                .HasOne(cg => cg.Company)
                .WithMany(c => c.CourtGroups)
                .HasForeignKey(cg => cg.CompanyId);

            modelBuilder.Entity<Court>()
                .HasOne(c => c.CourtGroup)
                .WithMany(cg => cg.Courts)
                .HasForeignKey(c => c.CourtGroupId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.BookingType)
                .WithMany(bt => bt.Bookings)
                .HasForeignKey(b => b.BookingTypeId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Customer)
                .WithMany(c => c.Bookings)
                .HasForeignKey(b => b.CustomerId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Court)
                .WithMany(c => c.Bookings)
                .HasForeignKey(b => b.CourtId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.FlexibleBooking)
                .WithMany(fb => fb.Bookings)
                .HasForeignKey(b => b.FlexibleBookingId);

            modelBuilder.Entity<BookingDetail>()
                .HasKey(bd => new {bd.CourtSlotId, bd.BookingId});
            modelBuilder.Entity<BookingDetail>()
                .HasOne(bd => bd.CourtSlot)
                .WithMany(cs => cs.BookingDetails)
                .HasForeignKey(bd => bd.CourtSlotId);
            modelBuilder.Entity<BookingDetail>()
                .HasOne(bd => bd.Booking)
                .WithMany(b => b.BookingDetails)
                .HasForeignKey(bd => bd.BookingId);

            modelBuilder.Entity<Price>()
                .HasKey(p => new {p.CourtSlotId, p.BookingTypeId});
            modelBuilder.Entity<Price>()
                .HasOne(p => p.CourtSlot)
                .WithMany(cs => cs.Prices)
                .HasForeignKey(p =>  p.CourtSlotId);
            modelBuilder.Entity<Price>()
                .HasOne(p => p.BookingType)
                .WithMany(bt => bt.Prices)
                .HasForeignKey(p => p.BookingTypeId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Company)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.CompanyId);

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.CourtGroup)
                .WithMany(cg => cg.Feedbacks)
                .HasForeignKey(f => f.CourtGroupId);
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.User)
                .WithMany(u => u.Feedbacks)
                .HasForeignKey(f => f.UserId);

            modelBuilder.Entity<Withdraw>()
                .HasOne(w => w.Company)
                .WithMany(c => c.Withdraws)
                .HasForeignKey(w => w.CompanyId);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.PaymentMethod)
                .WithMany(pm => pm.Payments)
                .HasForeignKey(p => p.PaymentMethodId);
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Company)
                .WithMany(c => c.Payments)
                .HasForeignKey(p => p.CompanyId);

            modelBuilder.Entity<ContactPoint>()
                .HasOne(cp => cp.CourtGroup)
                .WithMany(cg => cg.ContactPoints)
                .HasForeignKey(cp => cp.CourtGroupId);

            modelBuilder.Entity<CourtSlot>()
                .HasOne(cs => cs.CourtGroup)
                .WithMany(cg => cg.CourtSlots)
                .HasForeignKey(cs => cs.CourtGroupId);

            modelBuilder.Entity<FlexibleBooking>()
                .HasOne(fb => fb.Customer)
                .WithMany(c => c.FlexibleBookings)
                .HasForeignKey(fb => fb.CustomerId);

            modelBuilder.Entity<Service>()
                .HasOne(s => s.CourtGroup)
                .WithMany(cg => cg.Services)
                .HasForeignKey(s => s.CourtGroupId);

        }
    }
}
