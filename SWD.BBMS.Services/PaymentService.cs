using AutoMapper;
using SWD.BBMS.Repositories.Entities;
using SWD.BBMS.Repositories.Interfaces;
using SWD.BBMS.Services.BusinessModels;
using SWD.BBMS.Services.Interfaces;
using SWD.BBMS.Services.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IMapper mapper;

        private readonly IBookingRepository bookingRepository;

        private readonly IPaymentRepository paymentRepository;

        private readonly IPaymentMethodRepository paymentMethodRepository;

        public PaymentService(IMapper mapper, IBookingRepository bookingRepository, IPaymentRepository paymentRepository, IPaymentMethodRepository paymentMethodRepository)
        {
            this.mapper = mapper;
            this.bookingRepository = bookingRepository;
            this.paymentRepository = paymentRepository;
            this.paymentMethodRepository = paymentMethodRepository;
        }

        public Task<PaymentModel> CreateBankingPaymentForBooking(List<BookingModel> bookingModels, string bankCode, string transactionId)
        {
            throw new NotImplementedException();
        }

        public async Task<PaymentModel> CreateCashPaymentForBooking(List<BookingModel> bookingModels, double totalPrice)
        {
            try
            {
                var bookings = new List<Booking>();
                var paymentId = Guid.NewGuid().ToString();
                var idsString = "";
                foreach (var bookingModel in bookingModels)
                {
                    var booking = await bookingRepository.GetBookingById(bookingModel.Id);
                    if (booking == null)
                        throw new Exception($"Booking with id {bookingModel.Id} not found in CreateCashPaymentForBooking()");
                    bookings.Add(booking);
                    idsString += bookingModel.Id + ",";
                }
                var paymentMethod = await paymentMethodRepository.GetPaymentMethodByName("Cash");
                if (paymentMethod == null)
                    throw new Exception($"Payment method 'Cash' not found in CreateCashPaymentForBooking()");
                var payment = new Payment
                {
                    Id = paymentId,
                    Amount = totalPrice,
                    Bookings = bookings,
                    CompanyId = 1,
                    Date = DateTimeLibrary.UtcNowToSave(),
                    Description = "Payment for booking: " + idsString,
                    PaymentMethodId = paymentMethod.Id,
                    Success = true
                };
                var result = await paymentRepository.SavePayment(payment);
                if (!result)
                    throw new Exception("Something wrong when save new payment in CreateCashPaymentForBooking() service.");
                foreach(var booking in bookings)
                {
                    booking.PaymentId = paymentId;
                    booking.IsPaid = true;
                    if (!await bookingRepository.UpdateBooking(booking))
                        throw new Exception("Something wrong when update booking in CreateCashPaymentForBooking() service.");
                }
                var paymentModel = mapper.Map<PaymentModel>(payment);
                return paymentModel;
            }
            catch
            {
                throw;
            }
            

        }

        public async Task<PaymentModel?> GetPaymentByBookingId(int bookingId)
        {
            try
            {
                var payment = await paymentRepository.GetPaymentByBookingId(bookingId);
                return mapper.Map<PaymentModel>(payment);
            }
            catch
            {
                throw;
            }
        }
    }
}
