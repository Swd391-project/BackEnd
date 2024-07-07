using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SWD.BBMS.API.ViewModels.RequestModels
{
    public class CreateCourtGroupRequest
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        public string Address { get; set; }

        [Required]
        public TimeOnly StartTime { get; set; }

        [Required]
        public TimeOnly EndTime { get; set; }

        public long? Price { get; set; } = 100000;

        public string? ProfileImage { get; set; }

        public string? CoverImage { get; set; }
    }
}
