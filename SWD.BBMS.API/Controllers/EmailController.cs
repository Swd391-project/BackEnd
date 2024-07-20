using Microsoft.AspNetCore.Mvc;
using SWD.BBMS.Services.BusinessModels;
using SWD.BBMS.Services.Interfaces;

namespace SWD.BBMS.API.Controllers
{
    [ApiController]
    [Route("api/email")]
    public class EmailController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly IBookingService _bookingService;

        public EmailController(IEmailService emailService, IBookingService bookingService)
        {
            _emailService = emailService;
            _bookingService = bookingService;
        }

        [HttpPost]
        public async Task<IActionResult> SendBookingConfirmationEmailToUser([FromBody] string userEmail, [FromQuery] int bookingId)
        {
            var booking = await _bookingService.GetBookingById(bookingId);
            if (booking == null) return BadRequest();

            var bookedCourt = booking.Court;

            string subject = "Badminton Court Booking Confirmation";
            string message =
                $"Dear {userEmail}, your badminton court booking has been confirmed!<br><br>" +
                $"<strong>Booking Details:</strong><br>" +
                $"Court name: {bookedCourt.Name}<br>" +
                $"On date: {booking.CreatedDate.ToShortDateString()}, from {booking.FromTime} to {booking.ToTime}<br>";

            if (booking.Payment != null)
            {
                message +=
                    $"<br>Total booking price: {booking.Payment.Amount}<br>" +
                    $"Payment method: {booking.Payment.PaymentMethod}<br>";
            }

            message += 
                "<br>In case the information is not correct, please contact us by replying to this email to make adjustments as soon as possible.";

            await _emailService.SendEmailAsync(userEmail, subject, message);

            return Ok();
        }
    }
}
