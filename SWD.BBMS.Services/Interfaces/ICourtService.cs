using SWD.BBMS.Repositories;
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
    }
}
