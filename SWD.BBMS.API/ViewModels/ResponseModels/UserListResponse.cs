using System.Text.Json.Serialization;

namespace SWD.BBMS.API.ViewModels.ResponseModels
{
    public class UserListResponse
    {
        public string Id { get; set; }

        [JsonPropertyName("full-name")]
        public string FullName { get; set; }

        public string Username { get; set; }

        public string Role { get; set; }

    }
}
