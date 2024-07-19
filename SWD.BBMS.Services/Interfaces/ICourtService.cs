using SWD.BBMS.Repositories;
using SWD.BBMS.Repositories.Entities;
using SWD.BBMS.Services.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Services.Interfaces
{
    public interface ICourtService
    {
        Task<PagedList<CourtModel>> GetCourts(int pageNumber, int pageSize);

        Task<List<CourtModel>> GetCourtsNoPaging();

        Task<bool> SaveCourt(CourtModel model);

        Task<bool> UpdateCourtStatus(int id, CourtModelStatus status);

        Task<bool> DeleteCourt(int id);

        Task<CourtModel> GetCourtById(int id);

        Task<List<CourtModel>> GetCourtsByCourtGroupId(int courtGroupId);
    }
}
