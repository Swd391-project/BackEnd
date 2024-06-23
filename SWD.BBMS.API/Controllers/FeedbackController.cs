using Microsoft.AspNetCore.Mvc;
using SWD.BBMS.API.ViewModels.RequestModels;
using SWD.BBMS.Services.BusinessModels;
using SWD.BBMS.Services;
using SWD.BBMS.Services.Interfaces;
using System.Text.Json;

namespace SWD.BBMS.API.Controllers
{
    [ApiController]
    [Route("api/feedback")]
    public class FeedbackController : Controller
    {
        private readonly IFeedbackService feedbackService;

        private readonly IJwtService jwtService;

        public FeedbackController(IFeedbackService feedbackService, IJwtService jwtService)
        {
            this.feedbackService = feedbackService;
            this.jwtService = jwtService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeedbacks(int id, [FromQuery] OwnerParameters ownerParameters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var feebackModels = await feedbackService.GetFeedbacks(id, ownerParameters.PageNumber, ownerParameters.PageSize);

            var metadata = new
            {
                feebackModels.TotalCount,
                feebackModels.PageSize,
                feebackModels.CurrentPage,
                feebackModels.TotalPages,
                feebackModels.HasNext,
                feebackModels.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));
            return Ok(feebackModels);
        }

        [HttpGet("{id}/details")]
        public async Task<IActionResult> GetFeedbackDetails(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var feedbackModel = await feedbackService.GetFeedbackById(id);
            return Ok(feedbackModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeedback([FromBody] CreateFeedbackRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = false;
            try
            {
                var userId = await jwtService.GetUserId();
                var feedbackModel = new FeedbackModel
                {
                    Content = request.Content,
                    Rate = (float)request.Rate,
                    CourtGroupId = request.CourtGroupId,
                    ModifiedBy = userId,
                    UserId = userId
                };
                result = await feedbackService.SaveFeedback(feedbackModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            if (result)
            {
                return Ok("Feedback is created.");
            }
            return Ok("Feedback is not created.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFeedback(int id, [FromBody] UpdateFeedbackRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = false;
            try
            {
                var json = JsonSerializer.Serialize(request);
                if (json == null)
                {
                    return BadRequest(ModelState);
                }
                var feedbackDictModel = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
                result = await feedbackService.UpdateFeedback(id, feedbackDictModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            if (result)
            {
                return Ok("Feedback is updated.");
            }
            return Ok("Feedback is not updated.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = false;
            try
            {
                result = await feedbackService.DeleteFeedback(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            if (result)
            {
                return Ok("Feedback is deleted.");
            }
            return Ok("Feedback is not deleted.");
        }
    }
}
