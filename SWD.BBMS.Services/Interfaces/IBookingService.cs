﻿using Microsoft.AspNetCore.Http;
using SWD.BBMS.Repositories;
using SWD.BBMS.Repositories.Entities;
using SWD.BBMS.Repositories.Parameters;
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
        Task<int> SaveBooking(int id, BookingModel bookingModel);

        Task<PagedList<BookingModel>> GetBookings(int pageNumber, int pageSize);

        Task<BookingModel> GetBookingById(int id);

        Task<bool> DeleteBooking(int id);

        Task<bool> SaveFixedBooking(RecurrenceBookingModel bookingModel);

        Task<bool> SaveFlexibleBooking(FlexibleBookingModel bookingModel);

        Task<List<BookingModel>> GetBookingsByCourtGroupIdAndDate(int id, DateOnly date);

        Task<bool> CheckinBooking(int id, string userId);

        Task<bool> CheckoutBooking(int id, string userId);

        Task<PagedList<BookingModel>> GetBookingsHistoryByUserId(string id, BookingParameters bookingParameters);

        Task<PagedList<BookingModel>> GetUserBookingsByUserId(string id, BookingParameters bookingParameters);

    }
}
