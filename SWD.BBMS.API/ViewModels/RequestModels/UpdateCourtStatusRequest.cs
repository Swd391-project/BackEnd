using System.ComponentModel.DataAnnotations;

namespace SWD.BBMS.API.ViewModels.RequestModels
{
    public class UpdateCourtStatusRequest
    {
        [Required]
        public string Status { get; set; }
    }
}
