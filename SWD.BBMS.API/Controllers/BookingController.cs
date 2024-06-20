using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SWD.BBMS.API.EnumParsers;
using SWD.BBMS.API.ViewModels.RequestModels;
using SWD.BBMS.Services;
using SWD.BBMS.Services.BusinessModels;
using SWD.BBMS.Services.Interfaces;

namespace SWD.BBMS.API.Controllers
{
    [ApiController]
    [Route("api/booking")]
    public class BookingController : Controller
    {
        private readonly IJwtService jwtService;

        private readonly IBookingService bookingService;

        public BookingController(IJwtService jwtService, IBookingService bookingService)
        {
            this.jwtService = jwtService;
            this.bookingService = bookingService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = false;
            try
            {
                if (request.BookingTypeId != 1)
                {
                    return BadRequest("Booking type is not suitable.");
                }
                var userId = await jwtService.GetUserId();
                var customerModel = new CustomerModel
                {
                    FullName = request.FullName,
                    PhoneNumber = request.PhoneNumber
                };
                var bookingModel = new BookingModel
                {
                    Date = request.Date,
                    FromTime = request.FromTime,
                    ToTime = request.ToTime,
                    CourtId = request.CourtId,
                    BookingTypeId = request.BookingTypeId,
                    Note = request.Note,
                    Customer = (request.FullName.IsNullOrEmpty() || request.PhoneNumber.IsNullOrEmpty()) ? null : customerModel,
                    CreatedBy = userId,
                    ModifiedBy = userId,
                    Status = BookingModelStatus.Confirmed
                };
                result = await bookingService.SaveBooking(bookingModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            if (result)
            {
                return Ok("Booking is created.");
            }
            return Ok("Booking is not created.");
        }

        [HttpPost("test")]
        public IActionResult Test([FromBody]TimeOnlyTest test)
        {
            var toDay = test.Date.AddDays(7);
            var weekday = toDay.DayOfWeek.ToString();
            return Ok(new
            {
                Date = toDay,
                Weekday = weekday
            });
        }

    }
}
