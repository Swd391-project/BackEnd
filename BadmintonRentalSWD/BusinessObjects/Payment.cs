using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BadmintonRentalSWD.BusinessObjects
{
    [Table("Payment")]
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public long Amount { get; set; }

        public int BookingId { get; set; }

        public Booking Booking { get; set; }

        //public int CompanyId { get; set; }

        public Company Company { get; set; }

        //public int PaymentMethodId { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
    }
}
