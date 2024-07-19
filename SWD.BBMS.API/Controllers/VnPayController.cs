using Microsoft.AspNetCore.Mvc;
using SWD.BBMS.API.ViewModels.RequestModels;
using SWD.BBMS.Services.BusinessModels;
using SWD.BBMS.Services.Interfaces;

namespace SWD.BBMS.API.Controllers
{
    [ApiController]
    [Route("api/vn-pay")]
    public class VnPayController : Controller
    {

        private readonly IVnPayService vnPayService;

        public VnPayController(IVnPayService vnPayService)
        {
            this.vnPayService = vnPayService;
        }

        [HttpPost]
        public IActionResult CreatePaymentUrl([FromBody] VnPayRequest request)
        {

            var model = new Services.BusinessModels.PaymentModel
            {
                Amount = request.Amount,
                Description = request.Description
            };

            var requestUrl = HttpContext.Request;

            var url = vnPayService.CreatePaymentUrl(model, HttpContext, $"{requestUrl.Scheme}://{requestUrl.Host}{requestUrl.PathBase}{requestUrl.Path}");

            return Ok(new { url });
        }

        [HttpGet]
        public IActionResult PaymentCallback()
        {
            var response = vnPayService.PaymentExecute(Request.Query);

            return Json(response);
        }

        [HttpGet("payment-callback")]
        public async Task<IActionResult> BookingPaymentCallback()
        {
            try
            {
                var response = await vnPayService.BookingPaymentExecute(Request.Query);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
