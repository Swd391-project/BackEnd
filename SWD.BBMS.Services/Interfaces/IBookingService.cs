using SWD.BBMS.Repositories;
using SWD.BBMS.Services.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Services.Interfaces
{
    public interface IBookingService
    {
        Task<bool> SaveBooking(int id, BookingModel bookingModel);

        Task<PagedList<BookingModel>> GetBookings(int pageNumber, int pageSize);

        Task<BookingModel> GetBookingById(int id);

        Task<bool> DeleteBooking(int id);

        Task<bool> SaveFixedBooking(RecurrenceBookingModel bookingModel);

        Task<List<BookingModel>> GetBookingsByCourtGroupIdAndDate(int id, DateOnly date);

    }
}
