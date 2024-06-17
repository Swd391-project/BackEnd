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
    }
}
