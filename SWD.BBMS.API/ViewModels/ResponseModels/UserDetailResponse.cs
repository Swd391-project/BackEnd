using SWD.BBMS.Services.BusinessModels;
using System.Text.Json.Serialization;

namespace SWD.BBMS.API.ViewModels.ResponseModels
{
    public class UserDetailResponse
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Role { get; set; }

        public string? Image { get; set; }

        public string Status { get; set; }

        public int? CompanyId { get; set; }

        public string? CompanyName { get; set;}

    }
}
