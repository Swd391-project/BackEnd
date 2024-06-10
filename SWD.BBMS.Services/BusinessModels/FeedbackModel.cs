using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWD.BBMS.Services.BusinessModels
{
    public class FeedbackModel
    {
        public int Id { get; set; }

        public string? Content { get; set; }

        public float Rate { get; set; }

        public CourtGroupModel CourtGroup { get; set; }

        public UserModel User { get; set; }
    }
}
