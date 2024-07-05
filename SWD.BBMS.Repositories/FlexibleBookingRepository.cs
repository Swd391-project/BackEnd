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
    public class FlexibleBookingRepository : IFlexibleBookingRepository
    {
        public async Task<bool> DeleteFlexibleBooking(FlexibleBooking flexibleBooking)
        {
            var result = false;
            try
            {
                using var dbContext = new BBMSDbContext();
                dbContext.FlexibleBookings.Remove(flexibleBooking);
                await dbContext.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public async Task<List<FlexibleBooking>> GetFlexibleBookingByCustomerIdAndCourtGroupIdAndMonth(int customerId, int courtGroupId, int month)
        {
            var flexibleBookings = new List<FlexibleBooking>();
            try
            {
                using var dbContext = new BBMSDbContext();
                flexibleBookings =  await dbContext.FlexibleBookings
                    .Where(fb => (fb.CustomerId == customerId) 
                        && (fb.CourtGroupId == courtGroupId) 
                        && ((fb.Status == BookingStatus.InProgress) || (fb.Status == BookingStatus.Confirmed)) 
                        && (fb.ExpiredDate.Month == month))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return flexibleBookings;
        }

        public async Task<bool> SaveFlexibleBooking(FlexibleBooking flexibleBooking)
        {
            var result = false;
            try
            {
                using var dbContext = new BBMSDbContext();
                var customer = flexibleBooking.Customer;
                if(customer != null)
                {
                    dbContext.Customers.Add(customer);
                }
                dbContext.FlexibleBookings.Add(flexibleBooking);
                await dbContext.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public async Task<bool> UpdateFlexibleBooking(FlexibleBooking flexibleBooking)
        {
            var result = false;
            try
            {
                using var dbContext = new BBMSDbContext();
                dbContext.Attach(flexibleBooking).State = EntityState.Modified;
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
