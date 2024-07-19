using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Services.BusinessModels
{
    public class ScheduleBookingModel
    {
        public string Ids { get; set; }

        public string DaysOfWeek { get; set; }

        public string BookingDates { get; set; }

        public TimeOnly FromTime { get; set; }

        public TimeOnly ToTime { get; set; }

        public double TotalPrice { get; set; }

        public string CourtGroupName { get; set; }

        public CustomerModel Customer { get; set; }
    }
}
