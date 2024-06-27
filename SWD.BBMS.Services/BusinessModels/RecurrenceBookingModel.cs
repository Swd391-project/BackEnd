using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Services.BusinessModels
{
    public class RecurrenceBookingModel
    {
        public int Month { get; set; }

        public int Year { get; set; }

        public TimeOnly FromTime { get; set; }

        public TimeOnly ToTime { get; set; }

        public int CourtGroupId { get; set; }

        public int? BookingTypeId { get; set; }

        public List<string> Weekdays { get; set; }

        public CustomerModel? Customer { get; set; }

        public string? Note { get; set; }

        public string? CreatedBy { get; set; }
    }
}
