using CustomerManagement.Core.Exceptions;
using System.Net;
using System.Text.Json;

namespace CustomerManagementAPI.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly IWebHostEnvironment _env;

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
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            string message;
            string details = string.Empty;

            bool isDevelopment = !_env.IsDevelopment();

            switch (exception)
            {
                case APIException apiEx:
                    statusCode = HttpStatusCode.BadRequest;
                    message = apiEx.Message;
                    _logger.LogWarning(exception, $"Erro de API: {message}");
                    break;

                default:
                    message = "Erro interno do servidor";
                    if (isDevelopment)
                    {
                        details = exception.StackTrace ?? string.Empty;
                    }
                    _logger.LogError(exception, $"Erro não tratado: {exception.Message}");
                    break;
            }

            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";

            var errorResponse = new
            {
                Message = message,
                Details = details
            };

            await context.Response.WriteAsJsonAsync(errorResponse);
        }
    }
}
