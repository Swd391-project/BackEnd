using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Extensions;
using SWD.BBMS.API.EnumParsers;
using SWD.BBMS.API.ViewModels.RequestModels;
using SWD.BBMS.API.ViewModels.ResponseModels;
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

        [HttpPost("fixed/{id}")]
        public async Task<IActionResult> CreateFixedBooking(int id, [FromBody] CreateFixedBookingRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = false;
            try
            {
                if (request.BookingTypeId != 2)
                {
                    return BadRequest("Booking type is not suitable.");
                }
                var userId = await jwtService.GetUserId();
                var customerModel = new CustomerModel
                {
                    FullName = request.FullName,
                    PhoneNumber = request.PhoneNumber
                };
                var recurrenceBooking = new RecurrenceBookingModel
                {
                    Month = request.Month,
                    Year = request.Year,
                    CourtGroupId = id,
                    BookingTypeId = request.BookingTypeId,
                    FromTime = request.FromTime,
                    ToTime = request.ToTime,
                    CreatedBy = userId,
                    Note = request.Note,
                    Weekdays = request.Weekdays,
                    Customer = (request.FullName.IsNullOrEmpty() || request.PhoneNumber.IsNullOrEmpty()) ? null : customerModel
                };
              
                result = await bookingService.SaveFixedBooking(recurrenceBooking);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            if (result)
            {
                return Ok("Fixed Booking is created.");
            }
            return Ok("Fixed Booking is not created.");
        }

        [HttpGet]
        public async Task<IActionResult> GetBookings([FromQuery] OwnerParameters ownerParameters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bookingModels = await bookingService.GetBookings(ownerParameters.PageNumber, ownerParameters.PageSize);
            var response = bookingModels.Select(b => new BookingListResponse
            {
                Id = b.Id,
                Date = b.Date,
                FromTime = b.FromTime,
                ToTime = b.ToTime,
                Status = b.Status.GetDisplayName(),
                Note = b.Note
            });

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
            return Ok(response);
        }

        [HttpGet("court-group/{id}")]
        public async Task<IActionResult> GetBookingsByCourtGroupId(int id, [FromQuery] DateOnly date)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bookingModels = await bookingService.GetBookingsByCourtGroupIdAndDate(id, date);
            var response = bookingModels.Select(b => new BookingListResponse
            {
                Id = b.Id,
                Date = b.Date,
                FromTime = b.FromTime,
                ToTime = b.ToTime,
                Status = b.Status.GetDisplayName(),
                Note = b.Note
            });
            return Ok(response);
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

        [HttpGet("test")]
        public IActionResult Test()
        {
            // Step 1: Define the first day of the month
            DateOnly firstDayOfMonth = new DateOnly(2024, 6, 1);

            // Step 2: Define the list of days of the week you're interested in
            List<DayOfWeek> daysOfWeek = new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Wednesday };

            // Step 3: Get the days in the month that match the specified days of the week
            List<DateOnly> matchingDays = GetDaysOfWeekInMonth(firstDayOfMonth, daysOfWeek);

            return Ok(matchingDays);
        }

        private static List<DateOnly> GetDaysOfWeekInMonth(DateOnly firstDayOfMonth, List<DayOfWeek> daysOfWeek)
        {
            // List to hold the matching days
            List<DateOnly> result = new List<DateOnly>();

            // Calculate the number of days in the month
            int daysInMonth = DateTime.DaysInMonth(firstDayOfMonth.Year, firstDayOfMonth.Month);

            // Iterate over each day of the month
            for (int day = 1; day <= daysInMonth; day++)
            {
                DateOnly currentDay = new DateOnly(firstDayOfMonth.Year, firstDayOfMonth.Month, day);

                // Check if the current day of the week matches any in the provided list
                if (daysOfWeek.Contains(currentDay.DayOfWeek))
                {
                    result.Add(currentDay);
                }
            }
            return result;
        }

    }
}
