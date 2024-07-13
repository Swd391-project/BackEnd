using System.ComponentModel.DataAnnotations;

namespace SWD.BBMS.API.ViewModels.RequestModels
{
    public class CreateFlexibleBookingRequest
    {
        [Required]
        [Range(1, 12, ErrorMessage = "Month must between 1 and 12.")]
        public int Month { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Year must be greater than 0.")]
        public int Year { get; set; }

        [Required]
        [Range(1, float.MaxValue, ErrorMessage = "Total hours must be greater than 0.")]
        public float TotalHours { get; set; }

        //[Required]
        //public int CourtGroupId { get; set; }

        public string? PhoneNumber { get; set; }

        public string? FullName { get; set; }

        public string? Note { get; set; }
    }
}
