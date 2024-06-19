using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Services.BusinessModels
{
    public class WeekdayActivityModel
    {
        public int Id { get; set; }

        public WeekdayModel Weekday { get; set; }

        public List<CourtGroupActivityModel>? CourtGroupActivities { get; set; }
    }
}
