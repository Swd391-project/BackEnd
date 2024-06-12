using SWD.BBMS.Services.BusinessModels;
using System.Text.Json.Serialization;

namespace SWD.BBMS.API.ViewModels.ResponseModels
{
    public class UserDetailResponse
    {
        public string Id { get; set; }

        [JsonPropertyName("full-name")]
        public string FullName { get; set; }

        public string Email { get; set; }

        [JsonPropertyName("phone-number")]
        public string PhoneNumber { get; set; }

        public string Role { get; set; }

        public string? Image { get; set; }

        public string Status { get; set; }

        [JsonPropertyName("company-id")]
        public int? CompanyId { get; set; }

        [JsonPropertyName("company-name")]
        public string? CompanyName { get; set;}

    }
}
