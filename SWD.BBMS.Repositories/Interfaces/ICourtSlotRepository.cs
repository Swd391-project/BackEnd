using SWD.BBMS.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Repositories.Interfaces
{
    public interface ICourtSlotRepository
    {
        Task<List<CourtSlot>> GetAvailableCourtSlotsByCourtGroupId(int courtGroupId);

        Task<List<CourtSlot>> GetAvailableCourtSlotsByCourtGroupIdWithTime(int courtGroupId, TimeOnly fromTime, TimeOnly toTime);
    }
}
