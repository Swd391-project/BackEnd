using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWD.BBMS.Repositories.Entities
{
    [Table("BookingDetail")]
    public class BookingDetail
    {
        [Key]
        public int BookingId { get; set; }

        public Booking Booking { get; set; }

        [Key]
        public int CourtSlotId { get; set; }

        public CourtSlot CourtSlot { get; set; }
    }
}
