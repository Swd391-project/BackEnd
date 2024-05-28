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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<BookingDetail>()
                .HasKey(bd => bd.Id);
            modelBuilder.Entity<BookingDetail>()
                .HasOne(bd => bd.Booking)
                .WithMany(b => b.BookingDetails)
                .HasForeignKey(bd => bd.BookingId);
            modelBuilder.Entity<BookingDetail>()
                .HasOne(bd => bd.CourtSlot)
                .WithMany(cs => cs.BookingDetails)
                .HasForeignKey(bd => bd.CourtSlotId);
            */

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Payment)
                .WithOne(p => p.Booking)
                .HasForeignKey<Payment>(p => p.BookingId);
            modelBuilder.Entity<Payment>()
                .HasIndex(p => p.BookingId)
                .IsUnique();
        }
    }
}
