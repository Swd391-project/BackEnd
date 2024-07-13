using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWD.BBMS.Repositories.Entities
{
    [Table("Booking")]
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Code { get; set; }

        public DateOnly Date { get; set; }

        public string? Note { get; set; }

        public BookingStatus Status { get; set; }

        public TimeOnly FromTime { get; set; }

        public TimeOnly ToTime { get; set; }

        public double TotalCost { get; set; }

        public bool IsPaid { get; set; } = false;

        public DateTime? CheckinTime { get; set; }

        public DateTime? CheckoutTime { get; set; }

        public string? CheckinBy { get; set; }

        public string? CheckoutBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int BookingTypeId { get; set; }

        public BookingType BookingType { get; set; }

        public ICollection<BookingDetail> BookingDetails { get; set; }

        public int? PaymentId { get; set; }

        public Payment? Payment { get; set; }

        public int CourtId { get; set; }

        public Court Court { get; set; }

        public int? FlexibleBookingId { get; set; }

        public FlexibleBooking? FlexibleBooking { get; set; }

    }
}
