﻿using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SWD.BBMS.Repositories;
using SWD.BBMS.Repositories.Entities;
using SWD.BBMS.Repositories.Interfaces;
using SWD.BBMS.Services.BusinessModels;
using SWD.BBMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository bookingRepository;

        private readonly UserManager<User> userManager;

        private readonly ICustomerRepository customerRepository;

        private readonly ICourtRepository courtRepository;

        private readonly ICourtSlotRepository courtSlotRepository;

        private readonly IMapper mapper;

        public BookingService(IBookingRepository bookingRepository, IMapper mapper, UserManager<User> userManager, ICustomerRepository customerRepository, ICourtRepository courtRepository, ICourtSlotRepository courtSlotRepository)
        {
            this.bookingRepository = bookingRepository;
            this.mapper = mapper;
            this.userManager = userManager;
            this.customerRepository = customerRepository;
            this.courtRepository = courtRepository;
            this.courtSlotRepository = courtSlotRepository;
        }

        public async Task<bool> DeleteBooking(int id)
        {
            var result = false;
            try
            {
                var booking = await bookingRepository.GetBookingById(id);
                booking.Status = BookingStatus.Deleted;
                result = await bookingRepository.UpdateBooking(booking);
            }
            catch
            {
                throw;
            }
            return result;
        }

        public async Task<BookingModel> GetBookingById(int id)
        {
            try
            {
                var booking = await bookingRepository.GetBookingById(id);
                var bookingModel = mapper.Map<BookingModel>(booking);
                return bookingModel;
            }
            catch
            {
                throw;
            }
        }

        public async Task<PagedList<BookingModel>> GetBookings(int pageNumber, int pageSize)
        {
            try
            {
                var bookings = await bookingRepository.GetBookings(pageNumber, pageSize);
                var bookingModels = mapper.Map<PagedList<BookingModel>>(bookings);
                return new PagedList<BookingModel>(bookingModels, bookings.TotalCount, bookings.CurrentPage, bookings.PageSize);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> SaveBooking(int id, BookingModel bookingModel)
        {
            var result = false;
            try
            {
                //Customer
                if (bookingModel.Customer == null)
                {
                    var user = await userManager.FindByIdAsync(bookingModel.CreatedBy);
                    if (user == null)
                    {
                        throw new Exception("User not found in create booking.");
                    }
                    var customer = await customerRepository.GetCustomerByPhoneNumber(user.PhoneNumber);
                    if (customer == null)
                    {
                        bookingModel.Customer = new CustomerModel
                        {
                            FullName = user.FullName,
                            PhoneNumber = user.PhoneNumber
                        };
                    }
                    else
                    {
                        bookingModel.CustomerId = customer.Id;
                    }
                }
                else
                {
                    var customer = await customerRepository.GetCustomerByPhoneNumber(bookingModel.Customer.PhoneNumber);
                    if (customer != null)
                    {
                        bookingModel.CustomerId = customer.Id;
                        bookingModel.Customer = null;
                    }
                }
                //Court
                var courtId = await GetCourtIdAvailableForBookingOfCourtGroup(id, bookingModel.Date, bookingModel.FromTime, bookingModel.ToTime);
                if (courtId == 0)
                    throw new Exception($"There is no court available for booking in {bookingModel.Date} from {bookingModel.FromTime} to {bookingModel.ToTime}");
                bookingModel.CourtId = courtId;
                //Court slots
                var courtSlots = await courtSlotRepository.GetAvailableCourtSlotsByCourtGroupId(id);
                //Booking details
                var startTime = bookingModel.FromTime;
                var endTime = bookingModel.ToTime;
                courtSlots = courtSlots.Where(cs => (cs.FromTime == startTime) || (cs.ToTime == endTime) || (cs.FromTime > startTime && cs.FromTime < endTime)).ToList();
                var booking = mapper.Map<Booking>(bookingModel);
                booking.BookingDetails = new List<BookingDetail>();
                foreach(var courtSlot in courtSlots)
                {
                    var bookingDetail = new BookingDetail
                    {
                        CourtSlotId = courtSlot.Id,
                        Booking = booking
                    };
                    booking.BookingDetails.Add(bookingDetail);
                }

                result = await bookingRepository.SaveBooking(booking);
            }
            catch
            {
                throw;
            }
            return result;
        }

        public async Task<bool> SaveFixedBooking(RecurrenceBookingModel bookingModel)
        {
            var result = false;
            try
            {
                var existingCustomerId = 0;
                //Customer
                if (bookingModel.Customer == null)
                {
                    var user = await userManager.FindByIdAsync(bookingModel.CreatedBy);
                    if (user == null)
                    {
                        throw new Exception("User not found in create fixed booking.");
                    }
                    var customer = await customerRepository.GetCustomerByPhoneNumber(user.PhoneNumber);
                    if (customer == null)
                    {
                        bookingModel.Customer = new CustomerModel
                        {
                            FullName = user.FullName,
                            PhoneNumber = user.PhoneNumber
                        };
                    }
                    else
                    {
                        existingCustomerId = customer.Id;
                    }
                }
                else
                {
                    var customer = await customerRepository.GetCustomerByPhoneNumber(bookingModel.Customer.PhoneNumber);
                    if (customer != null)
                    {
                        existingCustomerId = customer.Id;
                        bookingModel.Customer = null;
                    }
                }
                //Court slots
                var courtSlots = await courtSlotRepository.GetAvailableCourtSlotsByCourtGroupId(bookingModel.CourtGroupId);
                var startTime = bookingModel.FromTime;
                var endTime = bookingModel.ToTime;
                courtSlots = courtSlots
                    .Where(cs 
                        => (cs.FromTime == startTime) 
                        || (cs.ToTime == endTime) 
                        || (cs.FromTime > startTime && cs.FromTime < endTime))
                    .ToList();

                var firstDayOfMonth = new DateOnly(bookingModel.Year, bookingModel.Month, 1);
                var daysInMonth = DateTime.DaysInMonth(bookingModel.Year, bookingModel.Month);
                var lastDayOfMonth = new DateOnly(bookingModel.Year, bookingModel.Month, daysInMonth);
                var daysOfWeek = ConvertStringsToDaysOfWeek(bookingModel.Weekdays);
                var daysOfBooking = GetDaysOfWeekInMonth(firstDayOfMonth, daysOfWeek, daysInMonth);
                //Bookings
                foreach (var day in daysOfBooking)
                {
                    var newBookingModel = new BookingModel
                    {
                        Date = day,
                        BookingTypeId = (int)bookingModel.BookingTypeId,
                        FromTime = bookingModel.FromTime,
                        ToTime = bookingModel.ToTime,
                        Note = bookingModel.Note,
                        Status = BookingModelStatus.Confirmed,
                        CreatedBy = bookingModel.CreatedBy,
                        CreatedDate = DateTime.UtcNow,
                        ModifiedBy = bookingModel.CreatedBy,
                        ModifiedDate = DateTime.UtcNow
                    };
                    if(existingCustomerId == 0)
                    {
                        newBookingModel.Customer = bookingModel.Customer;
                    }
                    else
                    {
                        newBookingModel.CustomerId = existingCustomerId;
                    }
                    var courtId = await GetCourtIdAvailableForBookingOfCourtGroup(bookingModel.CourtGroupId, day, bookingModel.FromTime, bookingModel.ToTime);
                    if (courtId == 0)
                        throw new Exception($"There is no court available for booking in {day} from {bookingModel.FromTime} to {bookingModel.ToTime}");
                    newBookingModel.CourtId = courtId;

                    var booking = mapper.Map<Booking>(newBookingModel);
                    booking.BookingDetails = new List<BookingDetail>();
                    foreach (var courtSlot in courtSlots)
                    {
                        var bookingDetail = new BookingDetail
                        {
                            CourtSlotId = courtSlot.Id,
                            Booking = booking
                        };
                        booking.BookingDetails.Add(bookingDetail);
                    }
                    result = await bookingRepository.SaveBooking(booking);
                    if (!result)
                        break;
                }
            }
            catch
            {
                throw;
            }
            return result;
        }

        private async Task<int> GetCourtIdAvailableForBookingOfCourtGroup(int courtGroupId, DateOnly date, TimeOnly fromTime, TimeOnly toTime)
        {
            try
            {
                var courts = await courtRepository.GetCourtsByCourtGroupId(courtGroupId);
                var courtModels = mapper.Map<List<CourtModel>>(courts);
                foreach(var courtModel in courtModels)
                {
                    if (courtModel.Bookings.IsNullOrEmpty())
                    {
                        return courtModel.Id;
                    }
                    var isOccupied = false;
                    foreach(var bookingModel in courtModel.Bookings)
                    {
                        if(bookingModel.Date != date 
                            || bookingModel.Status == BookingModelStatus.Cancelled 
                            || bookingModel.Status == BookingModelStatus.Completed)
                        {
                            continue;
                        }
                        foreach(var bookingDetailModel in bookingModel.BookingDetails)
                        {
                            if(bookingDetailModel.CourtSlot.FromTime ==  fromTime 
                                || bookingDetailModel.CourtSlot.ToTime == toTime 
                                || (bookingDetailModel.CourtSlot.FromTime > fromTime && bookingDetailModel.CourtSlot.FromTime < toTime))
                            {
                                isOccupied = true;
                                break;
                            }
                        }
                        if (isOccupied)
                            break;
                    }
                    if (!isOccupied)
                    {
                        return courtModel.Id;
                    }
                }
                return 0;
            }
            catch
            {
                throw;
            }
        }

        private static List<DayOfWeek> ConvertStringsToDaysOfWeek(List<string> dayStrings)
        {
            List<DayOfWeek> result = new List<DayOfWeek>();

            foreach (var dayString in dayStrings)
            {
                if (Enum.TryParse<DayOfWeek>(dayString, true, out DayOfWeek dayOfWeek))
                {
                    result.Add(dayOfWeek);
                }
                else
                {
                    Console.WriteLine($"'{dayString}' is not a valid day of the week.");
                }
            }

            return result;
        }

        private static List<DateOnly> GetDaysOfWeekInMonth(DateOnly firstDayOfMonth, List<DayOfWeek> daysOfWeek, int daysInMonth)
        {
            // List to hold the matching days
            List<DateOnly> result = new List<DateOnly>();

            // Iterate over each day of the month
            for (int day = 1; day <= daysInMonth; day++)
            {
                DateOnly currentDay = new DateOnly(firstDayOfMonth.Year, firstDayOfMonth.Month, day);

                // Check if the current day of the week matches any in the provided list
                if (daysOfWeek.Contains(currentDay.DayOfWeek))
                {
                    result.Add(currentDay);
                }
            }
            return result;
        }

        public async Task<List<BookingModel>> GetBookingsByCourtGroupIdAndDate(int id, DateOnly date)
        {
            try
            {
                var bookings = await bookingRepository.GetBookingsByCourtGroupIdAndDate(id, date);
                var bookingModels = mapper.Map<List<BookingModel>>(bookings);   
                return bookingModels;
            }
            catch
            {
                throw;
            }
        }
    }
}
