using System.Text.Json.Serialization;

namespace SWD.BBMS.API.ViewModels.ResponseModels
{
    public class UserListResponse
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public string Username { get; set; }

        public string Role { get; set; }

        public string Status { get; set; }

        public string? Image {  get; set; }

        public string? PhoneNumber { get; set; }

    }
}
