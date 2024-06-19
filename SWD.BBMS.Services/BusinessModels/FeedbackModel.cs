using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWD.BBMS.Services.BusinessModels
{
    public class FeedbackModel
    {
        public int Id { get; set; }

        public string? Content { get; set; }

        public float Rate { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        public CourtGroupModel CourtGroup { get; set; }

        public UserModel User { get; set; }
    }
}
