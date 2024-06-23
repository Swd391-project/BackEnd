using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
    public class CourtGroupRepository : ICourtGroupRepository
    {
        public async Task<CourtGroup?> FindCourtGroup(int id)
        {
            using var dbContext = new BBMSDbContext();
            return await dbContext.CourtGroups.FindAsync(id);
        }

        public async Task<CourtGroup?> GetCourtGroupById(int id)
        {
            using var dbContext = new BBMSDbContext();
            return await dbContext.CourtGroups
                .Include(cg => cg.CourtSlots)
                .Include(cg => cg.Courts)
                .Include(cg => cg.CourtGroupActivities).ThenInclude(cga => cga.WeekdayActivity)
                .FirstOrDefaultAsync(cg => cg.Id == id);
        }

        public async Task<PagedList<CourtGroup>> GetCourtGroups(int pageNumber, int pageSize)
        {
            var courtGroups = new PagedList<CourtGroup>();
            try
            {
                using var dbContext = new BBMSDbContext();
                courtGroups = await PagedList<CourtGroup>.ToPagedList(dbContext.CourtGroups, pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return courtGroups;
        }

        public async Task<bool> SaveCourtGroup(CourtGroup courtGroup)
        {
            var result = false;
            if (courtGroup == null)
            {
                return result;
            }
            try
            {
                using var dbContext = new BBMSDbContext();
                var courtGroupActivities = courtGroup.CourtGroupActivities;
                courtGroup.CourtGroupActivities = new List<CourtGroupActivity>();
                var courtSlots = courtGroup.CourtSlots;
                courtGroup.CourtSlots = new List<CourtSlot>();

                await dbContext.CourtGroups.AddAsync(courtGroup);
                if (!courtGroupActivities.IsNullOrEmpty())
                {
                    foreach (var courtGroupActivity in courtGroupActivities)
                    {
                        await dbContext.CourtGroupActivities.AddAsync(courtGroupActivity);
                    }
                }
                if (!courtSlots.IsNullOrEmpty())
                {
                    foreach(var courtSlot in courtSlots)
                    {
                        await dbContext.CourtSlots.AddAsync(courtSlot);
                    }
                }
                
                await dbContext.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public async Task<bool> UpdateCourtGroup(CourtGroup courtGroup)
        {
            var result = false;
            try
            {
                using var dbContext = new BBMSDbContext();
                dbContext.Attach(courtGroup).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        /*
private async Task<bool> SaveCourtGroupActivitiesOfCourtGroup(CourtGroup courtGroup, BBMSDbContext dbContext)
{
   try
   {

   }
   catch (Exception ex)
   {
       throw new Exception(ex.Message);
   }
}
*/
    }
}
