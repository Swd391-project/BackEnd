using System.Text.Json.Serialization;

namespace SWD.BBMS.API.ViewModels.RequestModels
{
    public class UserUpdateRequest : Dictionary<string, object>
    {
        [JsonPropertyName("full-name")]
        public string FullName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phone-number")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("image")]
        public string Image {  get; set; }
    }
}
