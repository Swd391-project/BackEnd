using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWD.BBMS.Repositories.Entities
{
    [Table("FlexibleBooking")]
    public class FlexibleBooking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public float TotalHours { get; set; }

        public float RemainingHours { get; set; }

        public DateOnly IssuedDate { get; set; }

        public DateOnly ExpiredDate { get; set; }

        public BookingStatus Status { get; set; }

        public long? TotalCost { get; set; }

        public string? Note {  get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int CourtGroupId { get; set; }

        public ICollection<Booking>? Bookings { get; set; }
    }
}
