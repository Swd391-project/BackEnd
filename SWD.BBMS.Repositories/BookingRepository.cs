using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SWD.BBMS.Repositories.Data;
using SWD.BBMS.Repositories.Entities;
using SWD.BBMS.Repositories.Helpers;
using SWD.BBMS.Repositories.Interfaces;
using SWD.BBMS.Repositories.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private ISortHelper<Booking> sortHelper;

        public BookingRepository(ISortHelper<Booking> sortHelper)
        {
            this.sortHelper = sortHelper;
        }

        public async Task<List<Booking>> GetAllBookingsByStatusAndDate(BookingStatus bookingStatus, DateOnly date)
        {
            try
            {
                using var dbContext = new BBMSDbContext();
                var bookings = await dbContext.Bookings
                    .Where(b => b.Status == bookingStatus && b.Date == date)
                    .ToListAsync();
                return bookings;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Booking?> GetBookingById(int id)
        {
            using var dbContext = new BBMSDbContext();
            return await dbContext.Bookings
                .Include(b=> b.BookingType)
                .Include(b => b.Customer)
                .Include(b => b.Court)
                .Include(b => b.FlexibleBooking)
                .Include(b => b.Payment)
                .Include(b => b.BookingDetails)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<PagedList<Booking>> GetBookings(int pageNumber, int pageSize)
        {
            try
            {
                using var dbContext = new BBMSDbContext();
                var bookings = await PagedList<Booking>
                    .ToPagedList(dbContext.Bookings.Include(b => b.Customer), pageNumber, pageSize);
                return bookings;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Booking>> GetBookingsDashboardPieChart()
        {
            try
            {
                using var dbContext = new BBMSDbContext();
                var bookings = await dbContext.Bookings
                    .Include(b => b.BookingType)
                    .Include(b => b.Customer)
                    .Include(b => b.Court)
                    .Include(b => b.FlexibleBooking)
                    .Include(b => b.Payment)
                    .Include(b => b.BookingDetails)
                    .Where(b => b.CreatedDate.Year == DateTime.UtcNow.Year)
                    .ToListAsync();
                // Group by status and select the first entry in each group
                var groupedBookings = bookings
                    .GroupBy(b => b.Status)
                    .ToDictionary(g => g.Key, g => g.First());

                // Get all possible statuses
                var allStatuses = Enum.GetValues(typeof(BookingStatus)).Cast<BookingStatus>();

                // Create the final list including all statuses
                var finalBookings = allStatuses.Select(status =>
                    groupedBookings.ContainsKey(status) ? groupedBookings[status] : new Booking { Status = status }
                ).OrderBy(b => (int)b.Status).ToList();

                return finalBookings;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> GetAmountByStatus(string status)
        {
            try
            {
                using var dbContext = new BBMSDbContext();
                var statusEnum = Enum.Parse<BookingStatus>(status);
                var bookings = await dbContext.Bookings
                    .Where(b => b.Status == statusEnum && b.CreatedDate.Year == DateTime.UtcNow.Year)
                    .ToListAsync();
                
                var amount = bookings.Count();
                return amount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Booking>> GetBookings()
        {
            using var dbContext = new BBMSDbContext();
            var bookings = await dbContext.Bookings.ToListAsync();
            return bookings;
        }

        public async Task<List<Booking>> GetBookingsByCourtGroupIdAndMonth(int id, DateTime date)
        {
            try
            {
                using var dbContext = new BBMSDbContext();
                var bookings = await dbContext.Bookings
                    .Include(b => b.Court)
                    .Include(b => b.Customer)
                    .Where(b => b.Court.CourtGroupId == id)
                    .Where(b => b.Date.Month == date.Month && b.Date.Year == date.Year)
                    .ToListAsync();
                return bookings;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Booking>> GetBookingsByCourtGroupIdAndDate(int id, DateOnly date)
        {
            try
            {
                using var dbContext = new BBMSDbContext();
                var bookings = await dbContext.Bookings
                    .Include(b => b.Court)
                    .Include(b => b.Customer)
                    .Where(b => b.Court.CourtGroupId == id)
                    .Where(b => b.Date == date)
                    .ToListAsync();
                return bookings;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PagedList<Booking>> GetBookingsHistoryByUserId(string id, BookingParameters bookingParameters)
        {
            try
            {
                using var dbContext = new BBMSDbContext();
                var user = await dbContext.Users.FindAsync(id);
                if(user == null)
                {
                    throw new Exception($"User with id {id} not found in GetBookingsHistoryByUserId() repository.");
                }
                var bookings = dbContext.Bookings
                    .Include(b => b.Customer)
                    .Include(b => b.Court).ThenInclude(c => c.CourtGroup)
                    .Where(b => (b.Customer.PhoneNumber.Equals(user.PhoneNumber)) 
                                && (b.Status == BookingStatus.Cancelled 
                                || b.Status == BookingStatus.Completed 
                                || b.Status == BookingStatus.Expired))
                    .AsQueryable();
                    
                return await PagedList<Booking>
                    .ToPagedList(bookings, bookingParameters.PageNumber, bookingParameters.PageSize);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PagedList<Booking>> GetUserBookingsByUserId(string id, BookingParameters bookingParameters)
        {
            try
            {
                using var dbContext = new BBMSDbContext();
                var user = await dbContext.Users.FindAsync(id);
                if (user == null)
                {
                    throw new Exception($"User with id {id} not found in GetBookingsHistoryByUserId() repository.");
                }
                var bookings = dbContext.Bookings
                    .Include(b => b.Customer)
                    .Include(b => b.Court).ThenInclude(c => c.CourtGroup)
                    .Where(b => (b.Customer.PhoneNumber.Equals(user.PhoneNumber)) 
                                && (b.Status == BookingStatus.Confirmed
                                || b.Status == BookingStatus.InProgress))
                    .AsQueryable();

                return await PagedList<Booking>
                    .ToPagedList(bookings, bookingParameters.PageNumber, bookingParameters.PageSize);
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
