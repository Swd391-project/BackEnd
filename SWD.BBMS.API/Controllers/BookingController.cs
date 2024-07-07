using Microsoft.AspNetCore.Authorization;
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

        private readonly IVnPayService vnPayService;

        public BookingController(IJwtService jwtService, IBookingService bookingService, IVnPayService vnPayService)
        {
            this.jwtService = jwtService;
            this.bookingService = bookingService;
            this.vnPayService = vnPayService;
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

        [HttpPost("flexible/{id}")]
        public async Task<IActionResult> CreateFlexibleBooking(int id, [FromBody]CreateFlexibleBookingRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = false;
            try
            {
                if (request.BookingTypeId != 3)
                {
                    return BadRequest("Booking type is not suitable.");
                }
                var userId = await jwtService.GetUserId();
                var customerModel = new CustomerModel
                {
                    FullName = request.FullName,
                    PhoneNumber = request.PhoneNumber
                };
                var today = DateOnly.FromDateTime(DateTime.Now);
                var firstDate = new DateOnly(request.Year, request.Month, 1);
                var lastDate = new DateOnly(request.Year, request.Month, DateTime.DaysInMonth(request.Year, request.Month));
                var flexibleBookingModel = new FlexibleBookingModel
                {
                    TotalHours = request.TotalHours,
                    RemainingHours = request.TotalHours,
                    IssuedDate = (today <  firstDate) ? firstDate : today,
                    ExpiredDate = lastDate,
                    Note = request.Note,
                    CourtGroupId = id,
                    CreatedBy = userId,
                    ModifiedBy = userId,
                    Customer = (request.FullName.IsNullOrEmpty() || request.PhoneNumber.IsNullOrEmpty()) ? null : customerModel
                };
                result = await bookingService.SaveFlexibleBooking(flexibleBookingModel);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            if (result)
            {
                return Ok("Flexible booking is created.");
            }
            return Ok("Flexible booking is not created.");
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
                Note = b.Note,
                CourtId = b.CourtId,
                CreatedDate = b.CreatedDate,
                Customer = new Customer4BookingList
                {
                    Id = b.CustomerId,
                    Name = b.Customer.FullName
                }
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
                CourtId = b.CourtId,
                FromTime = b.FromTime,
                ToTime = b.ToTime,
                Status = b.Status.GetDisplayName(),
                Note = b.Note,
                CreatedDate = b.CreatedDate,
                Customer = new Customer4BookingList
                {
                    Id = b.CustomerId,
                    Name = b.Customer.FullName
                }
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

        [HttpPut("check-in/{id}")]
        [Authorize(Roles = "Staff")]
        public async Task<IActionResult> CheckinBooking(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = false;
            try
            {
                var userId = await jwtService.GetUserId();  
                if (userId == null)
                {
                    return Unauthorized("User is not authenticated.");
                }
                result = await bookingService.CheckinBooking(id, userId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            if (result)
            {
                return Ok("Booking is checked-in.");
            }
            return Ok("Booking is not checked-in.");
        }

        [HttpPut("check-out/{id}")]
        [Authorize(Roles = "Staff")]
        public async Task<IActionResult> CheckoutBooking(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = false;
            try
            {
                var userId = await jwtService.GetUserId();
                if (userId == null)
                {
                    return Unauthorized("User is not authenticated.");
                }
                result = await bookingService.CheckoutBooking(id, userId);
                if (!result)
                {
                    return Ok("Booking is not checked-in.");
                }
                var bookingModel = await bookingService.GetBookingById(id);
                if (bookingModel == null)
                {
                    return StatusCode(500, "Booking not found in check-out controller.");
                }
                var requestUrl = HttpContext.Request;
                if (!bookingModel.IsPaid)
                {
                    var paymentUrl = vnPayService.CreatePaymentUrlForBooking(bookingModel, HttpContext, $"{requestUrl.Scheme}://{requestUrl.Host}");
                    return Ok(new { paymentUrl });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return Ok("Booking is checked-in.");
        }

    }
}
