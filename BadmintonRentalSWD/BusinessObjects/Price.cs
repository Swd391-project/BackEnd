using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BadmintonRentalSWD.BusinessObjects
{
    [Table("Price")]
    public class Price
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public long Cost { get; set; }

        //public int CourtSlotId { get; set; }

        public CourtSlot CourtSlot { get; set; }

        //public int BookingTypeId { get; set; }

        public BookingType BookingType { get; set; }
    }
}
