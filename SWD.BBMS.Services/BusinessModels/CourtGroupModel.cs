using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SWD.BBMS.Services.BusinessModels
{
    public class CourtGroupModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public float Rate { get; set; } = 0;

        public double PricePerHour { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public string? ProfileImage { get; set; }

        public string? CoverImage { get; set; }

        public CourtGroupModelStatus Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        [JsonIgnore]
        public List<CourtModel>? Courts { get; set; }

        [JsonIgnore]
        public List<CourtSlotModel>? CourtSlots { get; set; }

        public int CompanyId { get; set; }

        public CompanyModel Company { get; set; }

        public List<ContactPointModel>? ContactPoints { get; set; }

        public List<FeedbackModel>? Feedbacks { get; set; }

        public List<ServiceModel>? Services { get; set; }

        public List<CourtGroupActivityModel>? CourtGroupActivities { get; set; }
    }
}
