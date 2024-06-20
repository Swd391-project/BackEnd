using SWD.BBMS.Repositories.Entities;
using SWD.BBMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWD.BBMS.Services.BusinessModels;

namespace SWD.BBMS.Services.Interfaces
{
    public interface ICourtGroupService
    {
        Task<PagedList<CourtGroupModel>> GetCourtGroups(int pageNumber, int pageSize);

        Task<bool> SaveCourtGroup(CourtGroupModel courtGroupModel);

        Task<CourtGroupModel> GetCourtGroupById(int id);

        Task<List<AvailableCourtSLotModel>> GetAvailableCourtSlotInDate(int id, DateOnly date);
    }
}
