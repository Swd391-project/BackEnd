using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWD.BBMS.Services.BusinessModels
{
    public class CourtGroupModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public float? Rate { get; set; }

        public string FromDay { get; set; }

        public string ToDay { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public string? ProfileImage { get; set; }

        public string? CoverImage { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public List<CourtModel>? Courts { get; set; }

        public List<CourtSlotModel>? CourtSlots { get; set; }

        public CompanyModel Company { get; set; }

        public List<ContactPointModel>? ContactPoints { get; set; }

        public List<FeedbackModel>? Feedbacks { get; set; }

        public List<ServiceModel>? Services { get; set; }
    }
}
