using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWD.BBMS.Repositories.Entities
{
    [Table("Payment")]
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime Date { get; set; }

        public long Amount { get; set; }

        public string? TransactionId { get; set; }

        public bool Success { get; set; }

        //public string? Token { get; set; }

        //public string? VnPayResponseCode { get; set; }

        public int BookingId { get; set; }

        public Booking Booking { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }

        public int PaymentMethodId { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
    }
}
