using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Repositories.Entities
{
    [Table("WeekdayActivity")]
    public class WeekdayActivity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Weekday Weekday { get; set; }

        public ICollection<CourtGroupActivity>? CourtGroupActivities { get; set; }
    }
}
