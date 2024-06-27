using SWD.BBMS.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Repositories.Interfaces
{
    public interface ICourtGroupActivityRepository
    {
        Task<List<CourtGroupActivity>> GetCourtGroupActivitiesByCourtGroupId(int  courtGroupId);
    }
}
