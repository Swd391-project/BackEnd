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

        public string Code { get; set; }

        public DateOnly Date { get; set; }

        public string? Note { get; set; }

        public string Status { get; set; }

        public string Type { get; set; }

        public TimeOnly FromTime { get; set; }

        public TimeOnly ToTime { get; set; }
        public TimeOnly? CheckinTime { get; set; }
        public TimeOnly? CheckoutTime { get; set; }

        public string? CheckinBy { get; set; }

        public string? CheckoutBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        public Customer Customer { get; set; }

        public ICollection<BookingDetail> BookingDetails { get; set; }

        public Payment? Payment { get; set; }

        public Court Court { get; set; }

        public FlexibleBooking? FlexibleBooking { get; set; }

    }
}
