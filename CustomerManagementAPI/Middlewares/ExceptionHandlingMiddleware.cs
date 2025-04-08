using System.Net;

namespace CustomerManagementAPI.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        readonly RequestDelegate _next;
        readonly ILogger<ExceptionHandlingMiddleware> _logger;
        readonly IWebHostEnvironment _env;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger, IWebHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var isDevelopment = _env.IsDevelopment();
                string details = isDevelopment ? ex.StackTrace : string.Empty;

                object errorResponse = new {
                    Message = "Unexpected server error",
                    Details = details
                };

                await context.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }
}
