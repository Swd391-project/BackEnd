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
    }
}
