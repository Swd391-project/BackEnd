using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using SWD.BBMS.API.ViewModels.RequestModels;
using SWD.BBMS.API.ViewModels.ResponseModels;
using SWD.BBMS.Services.Interfaces;

namespace SWD.BBMS.API.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers([FromQuery]OwnerParameters ownerParameters)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var customerModels = await customerService.GetCustomers(ownerParameters.PageNumber, ownerParameters.PageSize);
                var response = customerModels.Select(c => new CustomerListResponse
                {
                    Id = c.Id,
                    FullName = c.FullName,
                    PhoneNumber = c.PhoneNumber
                });
                return Ok(response);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomers(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var customerModel =  await customerService.GetCustomerById(id);
                if (customerModel == null)
                {
                    return NoContent();
                }

                var bookingsResponse = customerModel.Bookings.Select(b => new BookingListResponse
                {
                    Id = b.Id,
                    Date = b.Date,
                    FromTime = b.FromTime,
                    ToTime = b.ToTime,
                    Status = b.Status.GetDisplayName(),
                    Note = b.Note
                }).ToList();

                var flexiblesResponse = customerModel.FlexibleBookings.Select(fb => new FlexibleListResponse
                {
                    Id = fb.Id,
                    TotalHours = fb.TotalHours,
                    RemainingHours = fb.RemainingHours,
                    IssuedDate = fb.IssuedDate,
                    ExpiredDate = fb.ExpiredDate
                }).ToList();

                var response = new CustomerDetailsResponse
                {
                    Id = customerModel.Id,
                    FullName = customerModel.FullName,
                    PhoneNumber = customerModel.PhoneNumber,
                    Bookings = bookingsResponse,
                    Flexibles = flexiblesResponse
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
