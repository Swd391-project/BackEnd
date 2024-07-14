using Microsoft.AspNetCore.Mvc;
using SWD.BBMS.Services;
using SWD.BBMS.Services.Interfaces;

namespace SWD.BBMS.API.Controllers
{
    [ApiController]
    [Route("api/momo")]
    public class MomoController : Controller
    {
        private readonly IMomoService momoService;

        public MomoController(IMomoService momoService)
        {
            this.momoService = momoService;
        }

        [HttpGet("payment-callback")]
        public async Task<IActionResult> PaymentCallback()
        {
            var response = await momoService.PaymentExecuteAsync(Request.Query);

            return Ok(response);
        }
    }
}
