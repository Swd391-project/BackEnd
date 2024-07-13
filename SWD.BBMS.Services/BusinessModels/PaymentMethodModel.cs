using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SWD.BBMS.Services.BusinessModels
{
    public class PaymentMethodModel
    {
        public int Id { get; set; }

        public string MethodName { get; set; }

        public string? Description { get; set; }

        [JsonIgnore]
        public List<PaymentModel>? Payments { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }
    }
}
