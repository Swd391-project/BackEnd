using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWD.BBMS.Services.BusinessModels
{
    public class PaymentModel
    {
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

        public BookingModel Booking { get; set; }

        public int CompanyId { get; set; }

        public CompanyModel Company { get; set; }

        public int PaymentMethodId { get; set; }

        public PaymentMethodModel PaymentMethod { get; set; }
    }
}
