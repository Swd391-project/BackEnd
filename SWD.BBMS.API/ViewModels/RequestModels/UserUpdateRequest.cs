using System.Text.Json.Serialization;

namespace SWD.BBMS.API.ViewModels.RequestModels
{
    public class UserUpdateRequest : Dictionary<string, object>
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Image {  get; set; }
    }
}
