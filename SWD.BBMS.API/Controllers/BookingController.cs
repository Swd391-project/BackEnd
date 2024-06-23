using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SWD.BBMS.API.EnumParsers;
using SWD.BBMS.API.ViewModels.RequestModels;
using SWD.BBMS.Services;
using SWD.BBMS.Services.BusinessModels;
using SWD.BBMS.Services.Interfaces;
using System.Text.Json;

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

        [HttpPost("{id}")]
        public async Task<IActionResult> CreateBooking(int id, [FromBody] CreateBookingRequest request)
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
                    BookingTypeId = request.BookingTypeId,
                    Note = request.Note,
                    Customer = (request.FullName.IsNullOrEmpty() || request.PhoneNumber.IsNullOrEmpty()) ? null : customerModel,
                    CreatedBy = userId,
                    ModifiedBy = userId,
                    Status = BookingModelStatus.Confirmed
                };
                result = await bookingService.SaveBooking(id, bookingModel);
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
        /*
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
        */

        [HttpGet]
        public async Task<IActionResult> GetBookings([FromQuery] OwnerParameters ownerParameters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bookingModels = await bookingService.GetBookings(ownerParameters.PageNumber, ownerParameters.PageSize);

            var metadata = new
            {
                bookingModels.TotalCount,
                bookingModels.PageSize,
                bookingModels.CurrentPage,
                bookingModels.TotalPages,
                bookingModels.HasNext,
                bookingModels.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));
            return Ok(bookingModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingDetails(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var feedbackModel = await bookingService.GetBookingById(id);
            return Ok(feedbackModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = false;
            try
            {
                result = await bookingService.DeleteBooking(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            if (result)
            {
                return Ok("Booking is deleted.");
            }
            return Ok("Booking is not deleted.");
        }

    }
}
