using System.ComponentModel.DataAnnotations;

namespace BadmintonRentalSWD.DTOs.Request
{
    public class RegisterRequest
    {
        [Required]
        public string FullName { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [MaxLength(12)]
        [MinLength(8)]
        public string? PhoneNumber { get; set; }

        [Required]
        public string Password { get; set; }

        public string? Role { get; set; }
    }
}
