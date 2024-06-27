using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SWD.BBMS.API.ViewModels.RequestModels
{
    public class CheckDaysOfWeekForFixedBookingRequest
    {
        [Required]
        [Range(1, 12, ErrorMessage = "The month must between 1 and 12.")]
        public int Month { get; set; }

        [Required]
        public uint Year { get; set; }

        [Required]
        [FromQuery(Name = "from-time")]
        public TimeOnly FromTime {  get; set; }

        [Required]
        [FromQuery(Name = "to-time")]
        public TimeOnly ToTime { get; set; }
    }
}
