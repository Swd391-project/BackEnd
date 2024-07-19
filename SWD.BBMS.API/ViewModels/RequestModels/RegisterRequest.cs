using SWD.BBMS.API.Validations;
using System.ComponentModel.DataAnnotations;

namespace SWD.BBMS.API.ViewModels.RequestModels
{
    public class RegisterRequest
    {
        [Required]
        public string FullName { get; set; }

        //[EmailAddress]
        [ValidEmail]
        public string? Email { get; set; }

        //[MaxLength(12)]
        //[MinLength(8)]
        [ValidPhoneNumber]
        public string? PhoneNumber { get; set; }

        [Required]
        public string Password { get; set; }

        public string? Role { get; set; } = "Customer";

        public string? Image {  get; set; }
    }
}
