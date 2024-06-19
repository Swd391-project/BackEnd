﻿using Microsoft.AspNetCore.Mvc;
using SWD.BBMS.API.EnumParsers;
using SWD.BBMS.API.ViewModels.RequestModels;
using SWD.BBMS.Services.BusinessModels;
using SWD.BBMS.Services.Interfaces;
using System.Text.Json;

namespace SWD.BBMS.API.Controllers
{
    [ApiController]
    [Route("/api/court")]
    public class CourtController : Controller
    {
        private readonly ICourtService courtService;

        private readonly IJwtService jwtService;

        public CourtController(ICourtService courtService, IJwtService jwtService)
        {
            this.courtService = courtService;
            this.jwtService = jwtService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourts([FromQuery]OwnerParameters ownerParameters)
        {
            var courts = await courtService.GetCourts(ownerParameters.PageNumber, ownerParameters.PageSize);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var metadata = new
            {
                courts.TotalCount,
                courts.PageSize,
                courts.CurrentPage,
                courts.TotalPages,
                courts.HasNext,
                courts.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));
            return Ok(courts);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourt([FromBody]CreateCourtRequest request)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var result = false;
            try
            {
                var userId = await jwtService.GetUserId();
                var courtModel = new CourtModel
                {
                    Status = EnumParser.ParseCourtModelStatus(request.Status),
                    CourtGroupId = request.CourtGroupId,
                    CreatedBy = userId,
                    ModifiedBy = userId
                };
                result = await courtService.SaveCourt(courtModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            if (result)
            {
                return Ok("Court is created.");
            }
            return Ok("Court is not created.");
        }
    }
}
