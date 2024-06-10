using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWD.BBMS.Services.BusinessModels
{
    public class CompanyModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Balance { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public List<CourtGroupModel>? CourtGroups { get; set; }

        public List<UserModel>? Users { get; set; }

        public List<WithdrawModel>? Withdraws { get; set; }

        public List<PaymentModel>? Payments { get; set; }
    }
}
