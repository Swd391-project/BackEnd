using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SWD.BBMS.Services.BusinessModels
{
    public class FeedbackModel
    {
        public int Id { get; set; }

        public string? Content { get; set; }

        public float Rate { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        public int CourtGroupId { get; set; }

        [JsonIgnore]
        public CourtGroupModel CourtGroup { get; set; }

        public string UserId { get; set; }

        public UserModel User { get; set; }
    }
}
