using SWD.BBMS.Repositories.Entities;
using SWD.BBMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWD.BBMS.Services.BusinessModels;
using SWD.BBMS.Repositories.Parameters;

namespace SWD.BBMS.Services.Interfaces
{
    public interface ICourtGroupService
    {
        Task<PagedList<CourtGroupModel>> GetCourtGroups(CourtGroupParameters courtGroupParameters);

        Task<bool> SaveCourtGroup(CourtGroupModel courtGroupModel);

        Task<CourtGroupModel> GetCourtGroupById(int id);

        Task<List<AvailableCourtSLotModel>> GetAvailableCourtSlotInDate(int id, DateOnly date);

        Task<bool> UpdateCourtGroup(int id, Dictionary<string, object> courtGroupDictModel);

        Task<bool> UpdateCourtGroupTimeAndPrice(int id, TimeOnly? startTime, TimeOnly? endTime, long price);

        Task<bool> DeleteCourtGroup(int id);

        Task<List<CourtGroupActivityModel>> GetAvailableDaysOfWeekForFixedBooking(int id, TimeOnly fromTime, TimeOnly toTime, int month, int year);
    }
}
