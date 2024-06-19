using System.ComponentModel.DataAnnotations;

namespace SWD.BBMS.API.ViewModels.RequestModels
{
    public class CreateCourtRequest
    {
        [Required]
        public string Status {  get; set; }

        [Required]
        public int CourtGroupId { get; set; }
    }
}
