using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SWD.BBMS.Services.BusinessModels
{
    public class BookingDetailModel
    {
        public int BookingId { get; set; }

        [JsonIgnore]
        public BookingModel Booking { get; set; }

        public int CourtSlotId { get; set; }

        public CourtSlotModel CourtSlot { get; set; }
    }
}
