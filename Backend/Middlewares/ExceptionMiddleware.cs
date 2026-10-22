using System.Net;
using System.Text.Json;
using Backend.Exceptions;
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
                var statusCode = ex switch
                {
                    BadRequestException => HttpStatusCode.BadRequest,
                    _ => HttpStatusCode.InternalServerError
                };

                context.Response.StatusCode = (int) statusCode;

                var response = new ApiResponse<object>(
                    statusCode: context.Response.StatusCode,
                    message: ex is BadRequestException ? ex.Message : "An unexpected error occurred.",
                    details:environment.IsDevelopment() ? ex.StackTrace : null
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