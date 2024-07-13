using System.ComponentModel.DataAnnotations;
using SWD.BBMS.API.Validations;

namespace SWD.BBMS.API.ViewModels.RequestModels
{
    public class CreateFixedBookingRequest
    {
        [Required]
        public int Month { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [ValidTimeOnly]
        public TimeOnly FromTime { get; set; }

        [Required]
        [ValidTimeOnly]
        public TimeOnly ToTime { get; set; }

        //[Required]
        //public int CourtGroupId { get; set; }

        public List<string> Weekdays { get; set; }

        public string? PhoneNumber { get; set; }

        public string? FullName { get; set; }

        public string? Note { get; set; }
    }
}
