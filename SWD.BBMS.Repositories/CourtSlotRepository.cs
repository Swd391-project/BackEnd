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
                courtSlots = await dbContext.CourtSlots
                    .Include(cs => cs.BookingDetails).ThenInclude(bd => bd.Booking).ThenInclude(b => b.Court)
                    .Where(cs => (cs.CourtGroupId == courtGroupId) && (cs.Status == SlotStatus.Available))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return courtSlots;
        }

        public async Task<List<CourtSlot>> GetAvailableCourtSlotsByCourtGroupIdWithTime(int courtGroupId, TimeOnly fromTime, TimeOnly toTime)
        {
            var courtSlots = new List<CourtSlot>();
            try
            {
                using var dbContext = new BBMSDbContext();
                courtSlots = await dbContext.CourtSlots
                    .Include(cs => cs.BookingDetails)
                    .ThenInclude(bd => bd.Booking)
                    .ThenInclude(b => b.Court)
                    .Where(cs => (cs.CourtGroupId == courtGroupId) 
                    && (cs.Status != SlotStatus.Closed) 
                    && (cs.FromTime == fromTime || cs.ToTime == toTime || (cs.FromTime > fromTime && cs.FromTime < toTime)))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return courtSlots;
        }

        public async Task<List<CourtSlot>> GetCourtSlotsByCourtGroupId(int courtGroupId)
        {
            var courtSlots = new List<CourtSlot>();
            try
            {
                using var dbContext = new BBMSDbContext();
                courtSlots = await dbContext.CourtSlots
                    .Where(cs => cs.CourtGroupId == courtGroupId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return courtSlots;
        }
    }
}
