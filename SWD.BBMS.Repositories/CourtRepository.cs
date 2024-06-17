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
    }
}
