using Microsoft.AspNetCore.Mvc;
using SWD.BBMS.API.ViewModels.RequestModels;
using SWD.BBMS.Services.Interfaces;
using System.Text.Json;

namespace SWD.BBMS.API.Controllers
{
    [ApiController]
    [Route("/api/court")]
    public class CourtController : Controller
    {
        private readonly ICourtService courtService;

        public CourtController(ICourtService courtService)
        {
            this.courtService = courtService;
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
    }
}
