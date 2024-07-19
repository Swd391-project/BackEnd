using Microsoft.AspNetCore.Mvc;
using SWD.BBMS.Repositories.Entities;
using SWD.BBMS.Repositories;
using SWD.BBMS.Services.Interfaces;
using SWD.BBMS.Services.BusinessModels;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http;

namespace SWD.BBMS.API.Controllers
{
    [ApiController]
    [Route("api/payment")]
    public class PaymentController : Controller
    {
        private readonly IBookingService bookingService;

        private readonly IMomoService momoService;

        private readonly IVnPayService vnPayService;

        private readonly IPaymentService paymentService;

        private readonly IJwtService jwtService;

        private readonly HttpClient httpClient;

        public PaymentController(IBookingService bookingService, IMomoService momoService, IVnPayService vnPayService, IPaymentService paymentService, IJwtService jwtService, HttpClient httpClient)
        {
            this.bookingService = bookingService;
            this.momoService = momoService;
            this.vnPayService = vnPayService;
            this.paymentService = paymentService;
            this.jwtService = jwtService;
            this.httpClient = httpClient;
        }

        [HttpGet("url/{id}")]
        public async Task<IActionResult> GetPaymentUrlForBooking(string id, [FromQuery(Name = "payment-option")] string paymentOption)
        {
            if (string.IsNullOrEmpty(paymentOption) || string.IsNullOrWhiteSpace(paymentOption))
                return BadRequest("Payment option is required.");
            var bookingIdStrings = id.Trim().Split(",");
            var bookingModels = new List<BookingModel>();
            double totalPrice = 0;
            for (int i = 0; i < bookingIdStrings.Length; i++)
            {
                if (int.TryParse(bookingIdStrings[i].Trim(), out var bookingId))
                {
                    var booking = await bookingService.GetBookingById(bookingId);
                    if (booking == null)
                    {
                        throw new Exception($"Booking with id {bookingId} not found in booking payment execute service.");
                    }
                    bookingModels.Add(booking);
                    totalPrice += booking.TotalCost;
                }
                else
                {
                    throw new Exception("Parse int unsuccess.");
                }
            }
            var paymentUrl = "";
            var requestUrl = HttpContext.Request;
            var currentPath = $"{requestUrl.Scheme}://{requestUrl.Host}";
            if (paymentOption.Equals("VnPay"))
            {
                paymentUrl = vnPayService.CreatePaymentUrlForBooking(bookingModels, HttpContext, currentPath);
            }
            else if (paymentOption.Equals("Momo"))
            {
                var orderInfo = new OrderInfoModel
                {
                    OrderInfo = id.Trim(),
                    Amount = totalPrice
                };
                var response = await momoService.CreatePaymentAsync(orderInfo, currentPath);
                paymentUrl = response.PayUrl;
            }
            else if (paymentOption.Equals("Cash"))
            {
                var response = await paymentService.CreateCashPaymentForBooking(bookingModels, totalPrice);
                return Ok(response);
            }

            return Ok(new { paymentUrl });
        }

        [HttpGet("refund/{id}")]
        public async Task<IActionResult> RefundPaymentOfBooking(int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id <= 0)
                return BadRequest("Invalid booking id.");
            try
            {
                var bookingModel = await bookingService.GetBookingById(id);
                if (bookingModel == null)
                    return BadRequest($"Booking with id {id} not found.");
                if(!bookingModel.IsPaid)
                    return Ok($"Booking with id {id} has not been paid yet.");
                var paymentModel = await paymentService.GetPaymentByBookingId(id);
                if(paymentModel == null)
                    return Ok($"Booking with id {id} has not been paid yet.");
                var userId = await jwtService.GetUserId();
                if (paymentModel.PaymentMethod.MethodName.Equals("VnPay"))
                {
                    var requestData = await vnPayService.CreateRefundPaymentUrl(HttpContext, paymentModel, userId);
                    var json = JsonConvert.SerializeObject(requestData);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync("https://sandbox.vnpayment.vn/merchant_webapi/api/transaction", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        return Ok(responseContent);
                    }
                    else
                    {
                        var errorContent = await response.Content.ReadAsStringAsync();
                        return StatusCode((int)response.StatusCode, errorContent);
                    }
                }else if (paymentModel.PaymentMethod.MethodName.Equals("Momo"))
                {
                    var response = await momoService.CreateRequestDataForMomoRefund(paymentModel);
                    return Ok(response);
                }
                return Ok("This booking payment method is not supported refund.");

            }catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
