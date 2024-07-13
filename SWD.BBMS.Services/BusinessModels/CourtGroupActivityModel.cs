using SWD.BBMS.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SWD.BBMS.Services.BusinessModels
{
    public class CourtGroupActivityModel
    {
        public int CourtGroupId { get; set; }
        [JsonIgnore]
        public CourtGroupModel CourtGroup { get; set; }

        public int WeekdayActivityId { get; set; }
        public WeekdayActivityModel WeekdayActivity { get; set; }

        public ActivityModelStatus ActivityStatus { get; set; }
    }
}
