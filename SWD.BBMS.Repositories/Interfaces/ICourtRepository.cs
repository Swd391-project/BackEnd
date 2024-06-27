using SWD.BBMS.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Repositories.Interfaces
{
    public interface ICourtRepository
    {
        Task<PagedList<Court>> GetCourts(int pageNumber, int pageSize);

        Task<Court?> FindCourt(int id);

        Task<bool> SaveCourt(Court court);  

        Task<List<Court>> GetCourtsByCourtGroupId(int courtGroupId);

        Task<bool> UpdateCourt(Court court);

        Task<Court?> GetCourtById(int id);

    }
}
