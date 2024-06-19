using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Repositories.Entities
{
    [Table("CourtGroupActivity")]
    public class CourtGroupActivity
    {
        [Key]
        public int CourtGroupId { get; set; }
        public CourtGroup CourtGroup { get; set; }

        [Key]
        public int WeekdayActivityId { get; set; }
        public WeekdayActivity WeekdayActivity { get; set; }

        public ActivityStatus ActivityStatus { get; set; }
    }
}
