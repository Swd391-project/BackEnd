using System.ComponentModel.DataAnnotations;

namespace SWD.BBMS.API.ViewModels.RequestModels
{
    public class CreateFixedBookingRequest
    {
        [Required]
        public int Month { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public TimeOnly FromTime { get; set; }

        [Required]
        public TimeOnly ToTime { get; set; }

        [Required]
        public int CourtId { get; set; }

        public int BookingTypeId { get; set; } = 2;

        public string? PhoneNumber { get; set; }

        public string? FullName { get; set; }

        public string? Note { get; set; }

        public List<string> Weekdays { get; set; }
    }
}
