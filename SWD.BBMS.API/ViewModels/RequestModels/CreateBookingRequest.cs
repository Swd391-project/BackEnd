using System.ComponentModel.DataAnnotations;
using SWD.BBMS.API.Validations;

namespace SWD.BBMS.API.ViewModels.RequestModels
{
    public class CreateBookingRequest
    {
        [Required]
        public DateOnly Date { get; set; }

        [Required]
        [ValidTimeOnly]
        public TimeOnly FromTime { get; set; }

        [Required]
        [ValidTimeOnly]
        public TimeOnly ToTime { get; set;}

        public string? PhoneNumber { get; set; }

        public string? FullName { get; set; }

        public string? Note { get; set; }

        public bool IsOnlinePayment { get; set; } = true;
    }
}
