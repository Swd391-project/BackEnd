using Microsoft.AspNetCore.Mvc;
using SWD.BBMS.API.ViewModels.ResponseModels;
using SWD.BBMS.Services.Interfaces;

namespace SWD.BBMS.API.Controllers
{
    [ApiController]
    [Route("api/file-record")]
    public class FileRecordController : Controller
    {

        private readonly IFileRecordService fileRecordService;

        public FileRecordController(IFileRecordService fileRecordService)
        {
            this.fileRecordService = fileRecordService;
        }

        [HttpGet("current-path")]
        public async Task<IActionResult> GetCurrentPath()
        {
            var request = HttpContext.Request;
            var fullUrl = $"{request.Scheme}://{request.Host}{request.Path}";
            var response = new
            {
                Scheme = request.Scheme,
                Host = request.Host,
                PathBase = request.PathBase,
                Path = request.Path,
                QueryString = request.QueryString
            };
            // Example: Log the full URL
            Console.WriteLine($"Full URL: {fullUrl}");
            var urlSegments = request.Path.ToString().Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            var newPath = "";
            foreach ( var segment in urlSegments)
            {
                if(segment.Equals("file-record"))
                {
                    newPath += "/" + segment + "/" + "download";
                    break;
                }
                newPath += "/" + segment;
            }
            var downloadUrl = $"{request.Scheme}://{request.Host}{request.PathBase}{newPath}";
            // Your existing file handling logic
            return Ok(new { downloadUrl });
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile (IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("No file uploaded.");
                }

                // Get the current controller path for download url
                var request = HttpContext.Request;
                var pathSegments = request.Path.ToString().Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                var newPath = "";
                foreach (var segment in pathSegments)
                {
                    if (segment.Equals("file-record"))
                    {
                        newPath += "/" + segment + "/download";
                        break;
                    }
                    newPath += "/" + segment;
                }
                var downloadUrl = $"{request.Scheme}://{request.Host}{request.PathBase}{newPath}";

                // Save file
                var model = await fileRecordService.SaveFileRecord(file, downloadUrl);
                var response = new SavedFileResponse
                {
                    Id = model.Id,
                    FileName = model.FileName,
                    Url = downloadUrl + "/" + model.Id
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); 
            }
        }

        [HttpGet("download/{id}")]
        public async Task<IActionResult> DownloadFile(int id)
        {
            try
            {
                var model = await fileRecordService.FindFileRecord(id);
                if (model == null)
                    return NoContent();

                return File(model.Data, model.ContentType, model.FileName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFile(int id)
        {
            var result = false;
            try
            {
                result = await fileRecordService.DeleteFileRecord(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            if(result)
                return Ok("Delete file successfully.");
            return Ok("Something went wrong when deleting file.");
        }
    }
}
