using Microsoft.EntityFrameworkCore;
using SWD.BBMS.Repositories.Data;
using SWD.BBMS.Repositories.Entities;
using SWD.BBMS.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Repositories
{
    public class WeekdayActivityRepository : IWeekdayActivityRepository
    {
        public async Task<List<WeekdayActivity>> GetWeekdayActivities()
        {
            var weekdayActivities = new List<WeekdayActivity>();
            try
            {
                using var dbContext = new BBMSDbContext();
                weekdayActivities = await dbContext.WeekdayActivities.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return weekdayActivities;
        }
    }
}
