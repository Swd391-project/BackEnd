using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
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
    public class VnPayService : IVnPayService
    {

        private readonly IConfiguration _configuration;

        private readonly IPaymentMethodRepository paymentMethodRepository;

        private readonly IPaymentRepository paymentRepository;

        private readonly IBookingRepository bookingRepository;

        public VnPayService(IConfiguration configuration, IPaymentMethodRepository paymentMethodRepository, IPaymentRepository paymentRepository, IBookingRepository bookingRepository)
        {
            _configuration = configuration;
            this.paymentMethodRepository = paymentMethodRepository;
            this.paymentRepository = paymentRepository;
            this.bookingRepository = bookingRepository;
        }

        public async Task<VnPayPaymentModel> BookingPaymentExecute(IQueryCollection collections)
        {
            try
            {
                var pay = new VnPayLibrary();
                var response = pay.GetFullResponseData(collections, _configuration["Vnpay:HashSecret"]);
                var paymentMethod = await paymentMethodRepository.GetPaymentMethodByName(response.PaymentMethodName);
                if (paymentMethod == null)
                {
                    throw new Exception("Payment method not found in booking payment execute service.");
                }

                var orderInfo = response.Description;
                var bookingIdsString = orderInfo.Split(": ")[1].Trim();
                var bookingIdStrings = bookingIdsString.Split(",");
                var bookings = new List<Booking>();
                for (int i = 0; i < bookingIdStrings.Length; i++)
                {
                    if (int.TryParse(bookingIdStrings[i].Trim(), out var bookingId))
                    {
                        var booking = await bookingRepository.GetBookingById(bookingId);
                        if (booking == null)
                        {
                            throw new Exception($"Booking with id {bookingId} not found in booking payment execute service.");
                        }
                        bookings.Add(booking);
                    }
                    else
                    {
                        throw new Exception("Parse int unsuccess.");
                    }
                }
               
                var payment = new Payment
                {
                    Id = response.OrderId,
                    Description = response.Description,
                    Amount = response.Amount,
                    Bookings = bookings,
                    CompanyId = 1,
                    TransactionId = response.TransactionId,
                    Date = response.PayDate,
                    Success = response.Success,
                    PaymentMethodId = paymentMethod.Id
                };
                var result = await paymentRepository.SavePayment(payment);
                foreach(var booking in bookings)
                {
                    booking.IsPaid = true;
                    booking.PaymentId = payment.Id;
                    if(!await bookingRepository.UpdateBooking(booking))
                        throw new Exception("Something went wrong when update booking in booking payment execute service.");
                }
                if (!result)
                    throw new Exception("Something went wrong when saving new payment in booking payment execute service.");
                return response;
            }
            catch
            {
                throw;
            }
        }

        public string CreatePaymentUrl(PaymentModel paymentModel, HttpContext context, string currentPath)
        {
            var timeZoneById = TimeZoneInfo.FindSystemTimeZoneById(_configuration["TimeZoneId"]);
            var timeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneById);
            var tick = DateTime.Now.Ticks.ToString();
            var pay = new VnPayLibrary();
            var urlCallBack = currentPath;

            pay.AddRequestData("vnp_Version", _configuration["Vnpay:Version"]);
            pay.AddRequestData("vnp_Command", _configuration["Vnpay:Command"]);
            pay.AddRequestData("vnp_TmnCode", _configuration["Vnpay:TmnCode"]);
            pay.AddRequestData("vnp_Amount", ((int)paymentModel.Amount * 100).ToString());
            pay.AddRequestData("vnp_CreateDate", timeNow.ToString("yyyyMMddHHmmss"));
            pay.AddRequestData("vnp_CurrCode", _configuration["Vnpay:CurrCode"]);
            pay.AddRequestData("vnp_IpAddr", pay.GetIpAddress(context));
            pay.AddRequestData("vnp_Locale", _configuration["Vnpay:Locale"]);
            pay.AddRequestData("vnp_OrderInfo", $"{paymentModel.Name} {paymentModel.Description} {paymentModel.Amount}");
            pay.AddRequestData("vnp_OrderType", "other");
            pay.AddRequestData("vnp_ReturnUrl", urlCallBack);
            pay.AddRequestData("vnp_TxnRef", tick);

            var paymentUrl =
                pay.CreateRequestUrl(_configuration["Vnpay:BaseUrl"], _configuration["Vnpay:HashSecret"]);

            return paymentUrl;
        }

        public string CreatePaymentUrlForBooking(List<BookingModel> bookingModels, HttpContext context, string currentPath)
        {
            var timeZoneById = TimeZoneInfo.FindSystemTimeZoneById(_configuration["TimeZoneId"]);
            var timeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneById);
            var orderId = Guid.NewGuid().ToString();
            var pay = new VnPayLibrary();
            var urlCallBack = currentPath + _configuration["PaymentCallBack:ReturnUrl"];
            double totalPrice = 0;
            var bookingIdsString = "";
            for (int i = 0; i < bookingModels.Count; i++)
            {
                totalPrice += bookingModels[i].TotalCost;
                if (i == bookingModels.Count - 1)
                {
                    bookingIdsString += bookingModels[i].Id;
                    continue;
                }
                bookingIdsString += bookingModels[i].Id + ",";
            }

            pay.AddRequestData("vnp_Version", _configuration["Vnpay:Version"]);
            pay.AddRequestData("vnp_Command", _configuration["Vnpay:Command"]);
            pay.AddRequestData("vnp_TmnCode", _configuration["Vnpay:TmnCode"]);
            pay.AddRequestData("vnp_Amount", (totalPrice * 100).ToString());
            pay.AddRequestData("vnp_CreateDate", timeNow.ToString("yyyyMMddHHmmss"));
            pay.AddRequestData("vnp_CurrCode", _configuration["Vnpay:CurrCode"]);
            pay.AddRequestData("vnp_IpAddr", pay.GetIpAddress(context));
            pay.AddRequestData("vnp_Locale", _configuration["Vnpay:Locale"]);
            pay.AddRequestData("vnp_OrderInfo", $"Payment for {bookingModels[0].BookingType.Name} booking: " + bookingIdsString);
            pay.AddRequestData("vnp_OrderType", "other");
            pay.AddRequestData("vnp_ReturnUrl", urlCallBack);
            pay.AddRequestData("vnp_TxnRef", orderId);

            var paymentUrl =
                pay.CreateRequestUrl(_configuration["Vnpay:BaseUrl"], _configuration["Vnpay:HashSecret"]);

            return paymentUrl;
        }

        public VnPayPaymentModel PaymentExecute(IQueryCollection collections)
        {
            var pay = new VnPayLibrary();
            var response = pay.GetFullResponseData(collections, _configuration["Vnpay:HashSecret"]);
            var payment = new Payment
            {
                
            };
            return response;
        }
    }
}
