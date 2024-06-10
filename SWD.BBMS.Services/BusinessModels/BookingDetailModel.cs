using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWD.BBMS.Services.BusinessModels
{
    public class BookingDetailModel
    {
        public int Id { get; set; }

        //public int BookingId { get; set; }

        public BookingModel Booking { get; set; }

        //public int CourtSlotId { get; set; }

        public CourtSlotModel CourtSlot { get; set; }
    }
}
