using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWD.BBMS.Repositories.Entities
{
    [Table("Price")]
    public class Price
    {
        
        public double Cost { get; set; }

        [Key]
        public int CourtSlotId { get; set; }

        public CourtSlot CourtSlot { get; set; }

        [Key]
        public int BookingTypeId { get; set; }

        public BookingType BookingType { get; set; }
    }
}
