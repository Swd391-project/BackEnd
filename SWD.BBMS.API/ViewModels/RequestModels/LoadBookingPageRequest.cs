using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SWD.BBMS.API.ViewModels.RequestModels
{
    public class LoadBookingPageRequest
    {
        [Required]
        [FromQuery(Name = "date")]
        public DateOnly Date {  get; set; }
    }
}
