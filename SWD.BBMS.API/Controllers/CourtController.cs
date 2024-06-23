using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using SWD.BBMS.API.EnumParsers;
using SWD.BBMS.API.ViewModels.RequestModels;
using SWD.BBMS.API.ViewModels.ResponseModels;
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourtStatus(int id, [FromBody]UpdateCourtStatusRequest request)
        {
            if(!ModelState.IsValid) { return BadRequest(ModelState); }
            var result = false;
            try
            {
                var status = EnumParser.ParseCourtModelStatus(request.Status);
                result = await courtService.UpdateCourtStatus(id, status);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            if(result)
            {
                return Ok($"Court status is updated to {request.Status}.");
            }
            return Ok($"Court status is not updated.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourt(int id)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var result = false;
            try
            {
                result = await courtService.DeleteCourt(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            if (result)
            {
                return Ok($"Court status is deleted.");
            }
            return Ok($"Court status is not deleted.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourtStatus(int id)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            try
            {
                var courtModel =  await courtService.GetCourtById(id);
                var response = new CourtDetailsResponse
                {
                    Id = courtModel.Id,
                    Status = courtModel.Status.GetDisplayName(),
                    CreatedDate = courtModel.CreatedDate,
                    ModifiedDate = courtModel.ModifiedDate,
                    CourtGroupName = courtModel.CourtGroup.Name
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
