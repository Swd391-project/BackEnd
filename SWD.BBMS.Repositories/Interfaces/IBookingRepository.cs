using SWD.BBMS.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        Task<bool> SaveBooking(Booking booking);

        Task<bool> UpdateBooking(Booking booking);

        Task<PagedList<Booking>> GetBookings(int pageNumber, int pageSize);

        Task<Booking?> GetBookingById(int id);

        Task<List<Booking>> GetBookingsByCourtGroupIdAndDate(int id, DateOnly date);
    }
}
