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
    public class CourtSlotRepository : ICourtSlotRepository
    {
        public async Task<List<CourtSlot>> GetAvailableCourtSlotsByCourtGroupId(int courtGroupId)
        {
            var courtSlots = new List<CourtSlot>();
            try
            {
                using var dbContext = new BBMSDbContext();
                courtSlots = await dbContext.CourtSlots.Where(cs => (cs.CourtGroupId == courtGroupId) && (cs.Status == SlotStatus.Available)).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return courtSlots;
        }
    }
}
