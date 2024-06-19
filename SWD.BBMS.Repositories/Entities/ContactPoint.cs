using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWD.BBMS.Repositories.Entities
{
    [Table("ContactPoint")]
    public class ContactPoint
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Contact { get; set; }

        public ContactType Type { get; set; }

        public CourtGroup CourtGroup { get; set; }
    }
}
