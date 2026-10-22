using System.Net;
using System.Text.Json;
using Backend.Responses;

namespace Backend.Middlewares
{
    public class ExceptionMiddleware(RequestDelegate next, IWebHostEnvironment environment)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

                var response = new ApiErrorResponse(
                    statusCode: context.Response.StatusCode,
                    message: "An unexpected error occurred.",
                    details:environment.IsDevelopment() ? ex.Message : null
                );
                
                var option = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };

                var json = JsonSerializer.Serialize(response, option);
                await context.Response.WriteAsync(json);
            }
        }
    }
}