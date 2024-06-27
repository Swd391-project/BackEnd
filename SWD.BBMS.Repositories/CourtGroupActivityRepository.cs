using Microsoft.EntityFrameworkCore;
using SWD.BBMS.Repositories.Data;
using SWD.BBMS.Repositories.Entities;
using SWD.BBMS.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SWD.BBMS.Repositories
{
    public class CourtGroupActivityRepository : ICourtGroupActivityRepository
    {
        public async Task<List<CourtGroupActivity>> GetCourtGroupActivitiesByCourtGroupId(int courtGroupId)
        {
            var courtGroupActivities = new List<CourtGroupActivity>();
            try
            {
                using var dbContext = new BBMSDbContext();
                courtGroupActivities = await dbContext.CourtGroupActivities
                    .Include(cga => cga.WeekdayActivity)
                    .Where(cga => cga.CourtGroupId == courtGroupId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return courtGroupActivities;
        }
    }
}
