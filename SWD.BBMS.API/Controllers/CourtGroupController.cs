using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SWD.BBMS.API.ViewModels.RequestModels;
using SWD.BBMS.Repositories.Entities;
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

        private readonly IJwtService jwtService;

        public CourtGroupController(ICourtGroupService courtGroupService, IJwtService jwtService)
        {
            this.courtGroupService = courtGroupService;
            this.jwtService = jwtService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourtGroups([FromQuery]OwnerParameters ownerParameters)
        {
            var courtGroupModels = await courtGroupService.GetCourtGroups(ownerParameters.PageNumber, ownerParameters.PageSize);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
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
                return Ok(courtGroupModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /*
        [HttpGet("booking-page/{id}")]
        public async Task<IActionResult> LoadBookingPageByCourtGroup(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        */
        
    }
}
