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
    public class CourtRepository : ICourtRepository
    {
        public async Task<Court?> FindCourt(int id)
        {
            using var dbContext = new BBMSDbContext();
            return await dbContext.Courts.FindAsync(id);
        }

        public async Task<PagedList<Court>> GetCourts(int pageNumber, int pageSize)
        {
            var courts = new PagedList<Court>();
            try
            {
                using var dbContext = new BBMSDbContext();
                courts = await PagedList<Court>.ToPagedList(dbContext.Courts.OrderBy(c => c.Id), pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return courts;
        }

        public async Task<List<Court>> GetCourtsByCourtGroupId(int courtGroupId)
        {
            var courts = new List<Court>();
            try
            {
                using var dbContext = new BBMSDbContext();
                courts = await dbContext.Courts
                    .Include(c => c.Bookings).ThenInclude(b => b.BookingDetails).ThenInclude(bd => bd.CourtSlot)
                    .Where(c => c.CourtGroupId == courtGroupId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return courts;
        }

        public async Task<bool> SaveCourt(Court court)
        {
            var result = false;
            try
            {
                using var dbContext = new BBMSDbContext();
                await dbContext.Courts.AddAsync(court);
                await dbContext.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}
