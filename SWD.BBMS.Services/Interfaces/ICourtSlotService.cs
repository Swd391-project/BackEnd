using SWD.BBMS.Services.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Services.Interfaces
{
    public interface ICourtSlotService
    {
        Task<List<AvailableSlotModel>> GetAvailableCourtSlotsOfCourtGroupInDate(int courtGroupId, DateOnly date);

        Task<List<CourtSlotModel>> GetCourtSlotsOfCourtGroup(int courtGroupId);
    }
}
