using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BadmintonRentalSWD.BusinessObjects
{
    [Table("Service")]
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public long Price { get; set; }

        public string Unit { get; set; }

        public CourtGroup CourtGroup { get; set; }
    }
}
