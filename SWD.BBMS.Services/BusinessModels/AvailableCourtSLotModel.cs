using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Services.BusinessModels
{
    public class AvailableCourtSLotModel
    {
        public int CourtId { get; set; }

        public int CourtSlotId { get; set; }

        public SlotModel CourtSlot { get; set; }

        public CourtModelStatus Status { get; set; }
    }
}
