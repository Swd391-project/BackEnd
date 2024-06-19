using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWD.BBMS.Services.BusinessModels
{
    public class CourtSlotModel
    {
        public int Id { get; set; }

        public TimeOnly FromTime { get; set; }

        public TimeOnly ToTime { get; set; }

        public string Status { get; set; }

        public long Price { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        public CourtGroupModel CourtGroup { get; set; }

        public List<BookingDetailModel>? BookingDetails { get; set; }

        public List<PriceModel>? Prices { get; set; }
    }
}
