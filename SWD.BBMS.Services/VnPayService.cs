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

        public VnPayService(IConfiguration configuration, IPaymentMethodRepository paymentMethodRepository, IPaymentRepository paymentRepository)
        {
            _configuration = configuration;
            this.paymentMethodRepository = paymentMethodRepository;
            this.paymentRepository = paymentRepository;
        }

        public async Task<VnPayPaymentModel> BookingPaymentExecute(int id, IQueryCollection collections)
        {
            try
            {
                if (id <= 0)
                    throw new Exception("Invalid id in booking payment execute service.");
                var pay = new VnPayLibrary();
                var response = pay.GetFullResponseData(collections, _configuration["Vnpay:HashSecret"]);
                var paymentMethod = await paymentMethodRepository.GetPaymentMethodByName(response.PaymentMethodName);
                if (paymentMethod == null)
                {
                    throw new Exception("Payment method not found in booking payment execute service.");
                }
                var payment = new Payment
                {
                    Amount = response.Amount,
                    BookingId = id,
                    CompanyId = 1,
                    TransactionId = response.TransactionId,
                    Date = response.PayDate,
                    Success = response.Success,
                    PaymentMethodId = paymentMethod.Id
                };
                var result = await paymentRepository.SavePayment(payment);
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
            pay.AddRequestData("vnp_OrderType", "Daily");
            pay.AddRequestData("vnp_ReturnUrl", urlCallBack);
            pay.AddRequestData("vnp_TxnRef", tick);

            var paymentUrl =
                pay.CreateRequestUrl(_configuration["Vnpay:BaseUrl"], _configuration["Vnpay:HashSecret"]);

            return paymentUrl;
        }

        public string CreatePaymentUrlForBooking(BookingModel bookingModel, HttpContext context, string currentPath)
        {
            var timeZoneById = TimeZoneInfo.FindSystemTimeZoneById(_configuration["TimeZoneId"]);
            var timeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneById);
            var tick = DateTime.Now.Ticks.ToString();
            var pay = new VnPayLibrary();
            var urlCallBack = currentPath + _configuration["PaymentCallBack:ReturnUrl"] + "/" + bookingModel.Id;

            pay.AddRequestData("vnp_Version", _configuration["Vnpay:Version"]);
            pay.AddRequestData("vnp_Command", _configuration["Vnpay:Command"]);
            pay.AddRequestData("vnp_TmnCode", _configuration["Vnpay:TmnCode"]);
            pay.AddRequestData("vnp_Amount", ((int)bookingModel.TotalCost * 100).ToString());
            pay.AddRequestData("vnp_CreateDate", timeNow.ToString("yyyyMMddHHmmss"));
            pay.AddRequestData("vnp_CurrCode", _configuration["Vnpay:CurrCode"]);
            pay.AddRequestData("vnp_IpAddr", pay.GetIpAddress(context));
            pay.AddRequestData("vnp_Locale", _configuration["Vnpay:Locale"]);
            pay.AddRequestData("vnp_OrderInfo", $"{bookingModel.BookingType.Name}");
            pay.AddRequestData("vnp_OrderType", bookingModel.BookingType.Name);
            pay.AddRequestData("vnp_ReturnUrl", urlCallBack);
            pay.AddRequestData("vnp_TxnRef", tick);

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
