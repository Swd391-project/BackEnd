using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SWD.BBMS.Services.BusinessModels
{
    public class ServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Unit { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        public int CourtGroupId { get; set; }

        [JsonIgnore]
        public CourtGroupModel CourtGroup { get; set; }
    }
}
