using Microsoft.AspNetCore.Mvc;
using SWD.BBMS.API.ViewModels.RequestModels;
using SWD.BBMS.Repositories.Entities;
using SWD.BBMS.Services.Interfaces;
using System.Text.Json;

namespace SWD.BBMS.API.Controllers
{
    [ApiController]
    [Route("/api/court-group")]
    public class CourtGroupController : Controller
    {
        private readonly ICourtGroupService courtGroupService;

        public CourtGroupController(ICourtGroupService courtGroupService)
        {
            this.courtGroupService = courtGroupService;
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
        public async Task<IActionResult> CreateCourtGroup([FromBody]CreateCourtGroupRequest request)
        {
            return Ok(request);
        }
    }
}
