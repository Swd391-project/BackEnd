using System.ComponentModel.DataAnnotations;

namespace SWD.BBMS.API.ViewModels.RequestModels
{
    public class LoadBookingPageRequest
    {
        [Required]
        public DateOnly Date {  get; set; }
    }
}
