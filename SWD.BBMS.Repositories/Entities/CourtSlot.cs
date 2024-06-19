using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWD.BBMS.Repositories.Entities
{
    [Table("CourtSlot")]
    public class CourtSlot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public TimeOnly FromTime { get; set; }

        public TimeOnly ToTime { get; set; }

        public SlotStatus Status { get; set; }

        public long Price { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        public int CourtGroupId { get; set; }

        public CourtGroup CourtGroup { get; set; }

        public ICollection<BookingDetail>? BookingDetails { get; set; }

        public ICollection<Price>? Prices { get; set; }
    }
}
