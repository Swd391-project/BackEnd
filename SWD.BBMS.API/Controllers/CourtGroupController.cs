using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using SWD.BBMS.API.ViewModels.RequestModels;
using SWD.BBMS.API.ViewModels.ResponseModels;
using SWD.BBMS.Repositories.Entities;
using SWD.BBMS.Repositories.Parameters;
using SWD.BBMS.Services;
using SWD.BBMS.Services.BusinessModels;
using SWD.BBMS.Services.Interfaces;
using System.Text.Json;

namespace SWD.BBMS.API.Controllers
{
    [ApiController]
    [Route("/api/court-group")]
    public class CourtGroupController : Controller
    {
        private readonly ICourtGroupService courtGroupService;

        private readonly ICourtSlotService courtSlotService;

        private readonly IJwtService jwtService;

        public CourtGroupController(ICourtGroupService courtGroupService, IJwtService jwtService, ICourtSlotService courtSlotService)
        {
            this.courtGroupService = courtGroupService;
            this.jwtService = jwtService;
            this.courtSlotService = courtSlotService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourtGroups([FromQuery]CourtGroupParameters courtGroupParameters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var courtGroupModels = await courtGroupService.GetCourtGroups(courtGroupParameters);
            var metadata = new
            {
                courtGroupModels.TotalCount,
                courtGroupModels.PageSize,
                courtGroupModels.CurrentPage,
                courtGroupModels.TotalPages,
                courtGroupModels.HasNext,
                courtGroupModels.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));
            return Ok(courtGroupModels);
        }
        
        [HttpPost]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> CreateCourtGroup([FromBody]CreateCourtGroupRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = false;
            try
            {
                var userId = await jwtService.GetUserId();
                var courtGroupModel = new CourtGroupModel
                {
                    Name = request.Name,
                    Address = request.Address,
                    StartTime = request.StartTime,
                    EndTime = request.EndTime,
                    ProfileImage = request.ProfileImage,
                    CoverImage = request.CoverImage,
                    CreatedBy = userId,
                    ModifiedBy = userId
                };
                result = await courtGroupService.SaveCourtGroup(courtGroupModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            if (result)
                return Ok("Court group is created.");
            return Ok("Court group is not created.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourtGroup(int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var courtGroupModel = await courtGroupService.GetCourtGroupById(id);
                var weekdayActivityResponse = courtGroupModel.CourtGroupActivities
                    .Select(cga => new WeekdayActivityCourtGroupDetails
                    {
                        Id = cga.WeekdayActivityId,
                        Weekday = cga.WeekdayActivity.Weekday.GetDisplayName(),
                        ActivityStatus = cga.ActivityStatus.GetDisplayName()
                    })
                    .ToList();
                var response = new CourtGroupDetailsResponse
                {
                    Id = courtGroupModel.Id,
                    Name = courtGroupModel.Name,
                    Address = courtGroupModel.Address,
                    StartTime = courtGroupModel.StartTime,
                    EndTime = courtGroupModel.EndTime,
                    CoverImage = courtGroupModel.CoverImage,
                    ProfileImage = courtGroupModel.ProfileImage,
                    Rate = courtGroupModel.Rate,
                    WeekdayActivities = weekdayActivityResponse
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("booking-page/{id}")]
        public async Task<IActionResult> LoadBookingPageByCourtGroup(int id, [FromBody]LoadBookingPageRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var availableCourtSlots = await courtSlotService.GetAvailableCourtSlotsOfCourtGroupInDate(id, request.Date);
                var response = availableCourtSlots.Select(cs => new CourtSlotBookingPage
                {
                    Id = cs.Id,
                    FromTime = cs.FromTime,
                    ToTime = cs.ToTime,
                    Price = cs.Price,
                    Status = cs.Status.GetDisplayName()
                }).ToList();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("fixed-booking-page/{id}")]
        public async Task<IActionResult> LoadFixedBookingPageByCourtGroup(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var courtSlots = await courtSlotService.GetCourtSlotsOfCourtGroup(id);
                var response = courtSlots.Select(cs => new CourtSlotBookingPage
                {
                    Id = cs.Id,
                    FromTime = cs.FromTime,
                    ToTime = cs.ToTime,
                    Price = cs.Price,
                    Status = cs.Status.GetDisplayName()
                }).ToList();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("fixed-booking-page/check-days-of-week/{id}")]
        public async Task<IActionResult> CheckDaysOfWeekForFixedBooking(int id, [FromQuery] CheckDaysOfWeekForFixedBookingRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var courtGroupActivityModels = await courtGroupService.GetAvailableDaysOfWeekForFixedBooking(id, request.FromTime, request.ToTime, request.Month, (int)request.Year);
                var response = courtGroupActivityModels.Select(cga => new WeekdayActivityCourtGroupDetails
                {
                    Id = cga.WeekdayActivityId,
                    Weekday = cga.WeekdayActivity.Weekday.GetDisplayName(),
                    ActivityStatus = cga.ActivityStatus.GetDisplayName()
                });
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourtGroup(int id, [FromBody]UpdateCourtGroupRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var json = JsonSerializer.Serialize(request);
                if (json == null)
                {
                    return BadRequest(ModelState);
                }
                var courtGroupDictModel = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
                if (courtGroupDictModel == null)
                {
                    return BadRequest(ModelState);
                }
                var success = await courtGroupService.UpdateCourtGroup(id, courtGroupDictModel);
                if (success)
                {
                    return Ok("Court group is updated.");
                }
                return Ok("Court group is not updated.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourtGroup(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = false;
            try
            {
                result = await courtGroupService.DeleteCourtGroup(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            if (result)
            {
                return Ok("Court group is deleted.");
            }
            return Ok("Court group is not deleted.");
        }
        
    }
}
