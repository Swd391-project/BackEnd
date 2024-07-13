using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SWD.BBMS.Services.BusinessModels
{
    public class CourtSlotModel
    {
        public int Id { get; set; }

        public TimeOnly FromTime { get; set; }

        public TimeOnly ToTime { get; set; }

        public SlotModelStatus Status { get; set; }

        public double Price { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        public int CourtGroupId { get; set; }

        [JsonIgnore]
        public CourtGroupModel CourtGroup { get; set; }

        [JsonIgnore]
        public List<BookingDetailModel>? BookingDetails { get; set; }

        [JsonIgnore]
        public List<PriceModel>? Prices { get; set; }
    }
}
