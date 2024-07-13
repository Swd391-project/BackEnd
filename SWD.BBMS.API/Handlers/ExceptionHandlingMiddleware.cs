using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace SWD.BBMS.API.Handlers
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (JsonException jsonEx)
            {
                _logger.LogError(jsonEx, "JSON serialization/deserialization error");
                await HandleJsonExceptionAsync(context, jsonEx);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception has occurred");
                await HandleExceptionAsync(context, ex);
            }
            
        }

        private static Task HandleJsonExceptionAsync(HttpContext context, JsonException jsonException)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var response = new { error = jsonException.Message };
            var json = JsonSerializer.Serialize(response);

            return context.Response.WriteAsync(json);
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new { error = exception.Message };
            var json = JsonSerializer.Serialize(response);

            return context.Response.WriteAsync(json);
        }
    }

}
