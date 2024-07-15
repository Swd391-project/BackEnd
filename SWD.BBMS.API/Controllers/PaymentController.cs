using Microsoft.AspNetCore.Mvc;
using SWD.BBMS.Repositories.Entities;
using SWD.BBMS.Repositories;
using SWD.BBMS.Services.Interfaces;
using SWD.BBMS.Services.BusinessModels;

namespace SWD.BBMS.API.Controllers
{
    [ApiController]
    [Route("api/payment")]
    public class PaymentController : Controller
    {
        private readonly IBookingService bookingService;

        private readonly IMomoService momoService;

        private readonly IVnPayService vnPayService;

        public PaymentController(IBookingService bookingService, IMomoService momoService, IVnPayService vnPayService)
        {
            this.bookingService = bookingService;
            this.momoService = momoService;
            this.vnPayService = vnPayService;
        }

        [HttpGet("url/{id}")]
        public async Task<IActionResult> GetPaymentUrlForBooking(string id, [FromQuery(Name = "payment-option")]string paymentOption)
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

            return Ok(new { paymentUrl });
        }
    }
}
