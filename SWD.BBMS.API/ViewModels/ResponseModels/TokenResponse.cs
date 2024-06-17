using System.Text.Json.Serialization;

namespace SWD.BBMS.API.ViewModels.ResponseModels
{
    public class TokenResponse
    {
        public string Token { get; set; }

        public string FullName { get; set; }

        public string Role { get; set; }

        public string Image {  get; set; }
    }
}
