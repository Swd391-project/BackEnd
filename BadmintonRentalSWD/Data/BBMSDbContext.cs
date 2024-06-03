using BadmintonRentalSWD.BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace BadmintonRentalSWD.Data
{
    public partial class BBMSDbContext : DbContext
    {
        public BBMSDbContext()
        {
        }

        public BBMSDbContext(DbContextOptions<BBMSDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(GetConnectionString());

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Payment)
                .WithOne(p => p.Booking)
                .HasForeignKey<Payment>(p => p.BookingId);
            modelBuilder.Entity<Payment>()
                .HasIndex(p => p.BookingId)
                .IsUnique();

            /*
            modelBuilder.Entity<BookingDetail>()
                .HasKey(bd => bd.Id);
            modelBuilder.Entity<BookingDetail>()
                .HasOne(bd => bd.Booking)
                .WithMany(b => b.BookingDetails)
                .HasForeignKey(bd => bd.BookingId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<BookingDetail>()
                .HasOne(bd => bd.CourtSlot)
                .WithMany(cs => cs.BookingDetails)
                .HasForeignKey(bd => bd.CourtSlotId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Company)
                .WithMany(c => c.Payments)
                .HasForeignKey(p => p.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.PaymentMethod)
                .WithMany(pm => pm.Payments)
                .HasForeignKey(p => p.PaymentMethodId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Price>()
                .HasOne(p => p.BookingType)
                .WithMany(bt => bt.Prices)
                .HasForeignKey(p => p.BookingTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Price>()
                .HasOne(p => p.CourtSlot)
                .WithMany(cs => cs.Prices)
                .HasForeignKey(p => p.CourtSlotId)
                .OnDelete(DeleteBehavior.Restrict);
            */
        }
    }
}
