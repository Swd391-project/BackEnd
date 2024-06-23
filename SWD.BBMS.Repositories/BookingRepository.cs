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
    public class BookingRepository : IBookingRepository
    {

        public async Task<Booking?> GetBookingById(int id)
        {
            using var dbContext = new BBMSDbContext();
            return await dbContext.Bookings.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<PagedList<Booking>> GetBookings(int pageNumber, int pageSize)
        {
            try
            {
                using var dbContext = new BBMSDbContext();
                var bookings = await PagedList<Booking>
                    .ToPagedList(dbContext.Bookings, pageNumber, pageSize);
                return bookings;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> SaveBooking(Booking booking)
        {
            var result = false;
            try
            {
                using var dbContext = new BBMSDbContext();
                var bookingDetails = booking.BookingDetails;
                booking.BookingDetails = new List<BookingDetail>();
                var customer = booking.Customer;
                if (customer != null)
                {
                    await dbContext.Customers.AddAsync(customer);
                }
                await dbContext.Bookings.AddAsync(booking);
                if (!bookingDetails.IsNullOrEmpty())
                {
                    foreach(var bookingDetail in bookingDetails)
                    {
                        await dbContext.BookingDetails.AddAsync(bookingDetail);
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

        public async Task<bool> UpdateBooking(Booking booking)
        {
            var result = false;
            try
            {
                using var dbContext = new BBMSDbContext();
                dbContext.Attach(booking).State = EntityState.Modified;
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
