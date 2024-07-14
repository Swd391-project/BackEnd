using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using RestSharp;
using SWD.BBMS.Repositories;
using SWD.BBMS.Repositories.Entities;
using SWD.BBMS.Repositories.Interfaces;
using SWD.BBMS.Services.BusinessModels;
using SWD.BBMS.Services.Interfaces;
using SWD.BBMS.Services.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Services
{
    public class MomoService : IMomoService
    {
        private readonly IOptions<MomoOptionModel> _options;

        private readonly IPaymentRepository paymentRepository;

        private readonly IBookingRepository bookingRepository;

        private readonly IPaymentMethodRepository paymentMethodRepository;

        public MomoService(IOptions<MomoOptionModel> options, IPaymentRepository paymentRepository, IBookingRepository bookingRepository, IPaymentMethodRepository paymentMethodRepository)
        {
            _options = options;
            this.paymentRepository = paymentRepository;
            this.bookingRepository = bookingRepository;
            this.paymentMethodRepository = paymentMethodRepository;
        }

        public async Task<MomoCreatePaymentResponseModel> CreatePaymentAsync(OrderInfoModel model, string currentPath)
        {
            model.OrderId = Guid.NewGuid().ToString();
            model.OrderInfo =
                "Payment for booking: " + model.OrderInfo;

            var returnUrl = currentPath + _options.Value.ReturnUrl + "/payment-callback";

            var rawData =
                $"partnerCode={_options.Value.PartnerCode}&accessKey={_options.Value.AccessKey}&requestId={model.OrderId}&amount={model.Amount}&orderId={model.OrderId}&orderInfo={model.OrderInfo}&returnUrl={returnUrl}&notifyUrl={_options.Value.NotifyUrl}&extraData=";

            var signature = ComputeHmacSha256(rawData, _options.Value.SecretKey);

            var client = new RestClient(_options.Value.MomoApiUrl);
            var request = new RestRequest() { Method = Method.Post };
            request.AddHeader("Content-Type", "application/json; charset=UTF-8");

            // Create an object representing the request data
            var requestData = new
            {
                accessKey = _options.Value.AccessKey,
                partnerCode = _options.Value.PartnerCode,
                requestType = _options.Value.RequestType,
                notifyUrl = _options.Value.NotifyUrl,
                returnUrl = returnUrl,
                orderId = model.OrderId,
                amount = model.Amount.ToString(),
                orderInfo = model.OrderInfo,
                requestId = model.OrderId,
                extraData = "",
                signature = signature
            };

            request.AddParameter("application/json", JsonConvert.SerializeObject(requestData), ParameterType.RequestBody);

            var response = await client.ExecuteAsync(request);

            return JsonConvert.DeserializeObject<MomoCreatePaymentResponseModel>(response.Content);
        }

        public async Task<MomoExecuteResponseModel> PaymentExecuteAsync(IQueryCollection collection)
        {
            var amount = collection.First(s => s.Key == "amount").Value;
            var orderInfo = collection.First(s => s.Key == "orderInfo").Value;
            var orderId = collection.First(s => s.Key == "orderId").Value;
            var orderType = collection.First(s => s.Key == "orderType").Value;
            var transId = collection.First(s => s.Key == "transId").Value;
            var message = collection.First(s => s.Key == "message").Value;
            var errorCode = collection.First(s => s.Key == "errorCode").Value;
            var payType = collection.First(s => s.Key == "payType").Value;

            // Save payment for booking
            if (int.Parse(errorCode) != 0)
            {
                throw new Exception("Your payment executed unsuccessfully.");
            }
            var bookingIdsString = orderInfo.ToString().Split(": ")[1].Trim();
            var bookingIdStrings = bookingIdsString.Split(", ");
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

            // Find payment method
            var paymentMethod = await paymentMethodRepository.GetPaymentMethodByName("Momo");
            if (paymentMethod == null)
            {
                throw new Exception($"Payment method with name Momo not found in PaymentExecuteAsync service.");
            }
            var payment = new Payment
            {
                Amount = double.Parse(amount),
                Date = DateTimeLibrary.UtcNowToSave(),
                PaymentMethodId = paymentMethod.Id,
                Success = true,
                Description = orderInfo,
                TransactionId = transId.ToString(),
                Id = orderId.ToString(),
                CompanyId = 1,
                Bookings = bookings
            };
            if(!await paymentRepository.SavePayment(payment))
            {
                throw new Exception("Something went wrong when save new payment in PaymentExecuteAsync service.");
            }
            foreach (var booking in bookings)
            {
                booking.IsPaid = true;
                booking.PaymentId = payment.Id;
                if(!await bookingRepository.UpdateBooking(booking))
                {
                    throw new Exception("Something went wrong when update booking in PaymentExecuteAsync service.");
                }
            }
            return new MomoExecuteResponseModel()
            {
                Amount = amount,
                OrderId = orderId,
                OrderInfo = orderInfo
            };
        }

        private string ComputeHmacSha256(string message, string secretKey)
        {
            var keyBytes = Encoding.UTF8.GetBytes(secretKey);
            var messageBytes = Encoding.UTF8.GetBytes(message);

            byte[] hashBytes;

            using (var hmac = new HMACSHA256(keyBytes))
            {
                hashBytes = hmac.ComputeHash(messageBytes);
            }

            var hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

            return hashString;
        }
    }
}
