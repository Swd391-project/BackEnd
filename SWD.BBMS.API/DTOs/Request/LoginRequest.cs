using System.ComponentModel.DataAnnotations;

namespace BadmintonRentalSWD.DTOs.Request
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
