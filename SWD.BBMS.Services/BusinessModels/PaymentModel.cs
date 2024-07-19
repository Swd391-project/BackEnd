using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SWD.BBMS.Services.BusinessModels
{
    public class PaymentModel
    {
        public string Id { get; set; }

        public string? Description { get; set; }

        public DateTime Date { get; set; }

        public double Amount { get; set; }

        public string? TransactionId { get; set; }

        public bool Success { get; set; }

        //public string? Token { get; set; }

        //public string? VnPayResponseCode { get; set; }

        [JsonIgnore]
        public List<BookingModel> Bookings { get; set; }

        public int CompanyId { get; set; }

        public CompanyModel Company { get; set; }

        public int PaymentMethodId { get; set; }

        public PaymentMethodModel PaymentMethod { get; set; }
    }
}
