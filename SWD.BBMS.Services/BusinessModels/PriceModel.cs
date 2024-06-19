using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWD.BBMS.Services.BusinessModels
{
    public class PriceModel
    {
        public long Cost { get; set; }

        public int CourtSlotId { get; set; }

        public CourtSlotModel CourtSlot { get; set; }

        public int BookingTypeId { get; set; }

        public BookingTypeModel BookingType { get; set; }
    }
}
