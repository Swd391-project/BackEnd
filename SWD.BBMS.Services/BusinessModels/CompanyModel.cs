using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SWD.BBMS.Services.BusinessModels
{
    public class CompanyModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Balance { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        [JsonIgnore]
        public List<CourtGroupModel>? CourtGroups { get; set; }

        [JsonIgnore]
        public List<UserModel>? Users { get; set; }

        [JsonIgnore]
        public List<WithdrawModel>? Withdraws { get; set; }

        [JsonIgnore]
        public List<PaymentModel>? Payments { get; set; }
    }
}
