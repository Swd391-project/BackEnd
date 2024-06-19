using AutoMapper;
using Microsoft.AspNetCore.Identity;
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

        public async Task<bool> SaveBooking(BookingModel bookingModel)
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
                var court = await courtRepository.FindCourt(bookingModel.CourtId);
                if (court == null)
                {
                    throw new Exception($"Court with id {bookingModel.CourtId} not found in create booking.");
                }
                //Court slots
                var courtGroupId = court.CourtGroupId;
                var courtSlots = await courtSlotRepository.GetAvailableCourtSlotsByCourtGroupId(courtGroupId);
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
    }
}
