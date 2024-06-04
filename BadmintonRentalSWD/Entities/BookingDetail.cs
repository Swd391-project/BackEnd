using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BadmintonRentalSWD.Entities
{
    [Table("BookingDetail")]
    public class BookingDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //public int BookingId { get; set; }

        public Booking Booking { get; set; }

        //public int CourtSlotId { get; set; }

        public CourtSlot CourtSlot { get; set; }
    }
}
