using SWD.BBMS.Repositories.Entities;
using SWD.BBMS.Repositories.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetAllBookingsByStatusAndDate(BookingStatus bookingStatus, DateOnly date);

        Task<bool> SaveBooking(Booking booking);

        Task<bool> UpdateBooking(Booking booking);

        Task<PagedList<Booking>> GetBookings(int pageNumber, int pageSize);

        Task<List<Booking>> GetBookingsDashboardPieChart();

        Task<int> GetAmountByStatus(string status);

        Task<List<Booking>> GetBookings();

        Task<Booking?> GetBookingById(int id);

        Task<List<Booking>> GetBookingsByCourtGroupIdAndDate(int id, DateOnly date);

        Task<List<Booking>> GetBookingsByCourtGroupIdAndMonth(int id, DateTime date);

        Task<PagedList<Booking>> GetBookingsHistoryByUserId(string id, BookingParameters bookingParameters);

        Task<PagedList<Booking>> GetUserBookingsByUserId(string id, BookingParameters bookingParameters);
    }
}
