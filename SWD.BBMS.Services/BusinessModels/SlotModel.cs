using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Services.BusinessModels
{
    public class SlotModel
    {
        public int Id { get; set; }

        public TimeOnly FromTime { get; set; }

        public TimeOnly ToTime { get; set; }

        //public SlotModelStatus Status { get; set; }

        public double Price { get; set; }
    }
}
