using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BadmintonRentalSWD.BusinessObjects
{
    [Table("Feedback")]
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Content { get; set; }

        public float Rate { get; set; }

        public CourtGroup CourtGroup { get; set; }

        public User User { get; set; }
    }
}
