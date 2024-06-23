using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SWD.BBMS.API.ViewModels.RequestModels;
using SWD.BBMS.Services;
using SWD.BBMS.Services.BusinessModels;
using SWD.BBMS.Services.Interfaces;
using System.Text.Json;

namespace SWD.BBMS.API.Controllers
{
    [ApiController]
    [Route("api/service")]
    public class ServiceController : Controller
    {
        private readonly IServiceService serviceService;

        private readonly IJwtService jwtService;

        public ServiceController(IServiceService serviceService, IJwtService jwtService)
        {
            this.serviceService = serviceService;
            this.jwtService = jwtService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetServices(int id, [FromQuery]OwnerParameters ownerParameters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var serviceModels = await serviceService.GetServices(id, ownerParameters.PageNumber, ownerParameters.PageSize);
            
            var metadata = new
            {
                serviceModels.TotalCount,
                serviceModels.PageSize,
                serviceModels.CurrentPage,
                serviceModels.TotalPages,
                serviceModels.HasNext,
                serviceModels.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));
            return Ok(serviceModels);
        }

        [HttpGet("{id}/details")]
        public async Task<IActionResult> GetServiceDetails(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var serviceModel = await serviceService.GetServiceById(id);
            return Ok(serviceModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateService([FromBody]CreateServiceRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = false;
            try
            {
                var userId = await jwtService.GetUserId();
                var serviceModel = new ServiceModel
                {
                    Name = request.Name,
                    Unit = request.Unit,
                    Price = request.Price,
                    CourtGroupId = request.CourtGroupId,
                    CreatedBy = userId,
                    ModifiedBy = userId
                };
                result = await serviceService.SaveService(serviceModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            if (result)
            {
                return Ok("Service is created.");
            }
            return Ok("Service is not created.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateService(int id, [FromBody] UpdateServiceRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = false;
            try
            {
                var json = JsonSerializer.Serialize(request);
                if (json.IsNullOrEmpty())
                {
                    return BadRequest(ModelState);
                }
                var serviceDictModel = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
                result = await serviceService.UpdateService(id, serviceDictModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            if (result)
            {
                return Ok("Service is created.");
            }
            return Ok("Service is not created.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = false;
            try
            {
                result = await serviceService.DeleteService(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            if (result)
            {
                return Ok("Service is created.");
            }
            return Ok("Service is not created.");
        }
    }
}
