using System.Net;
using System.Text.Json;
using ApplicationCore.Exceptions;
using ApplicationCore.Models.ResponseModels;

namespace MovieShop.API.Infrastructure;

public class MovieShopExceptionMiddleware
{
    private readonly ILogger<MovieShopExceptionMiddleware> _logger;
    private readonly RequestDelegate _next;

    public MovieShopExceptionMiddleware(ILogger<MovieShopExceptionMiddleware> logger, RequestDelegate next)
    {
        _logger = logger;
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            _logger.LogError("Something went wrong, inside exception middleware");
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        _logger.LogInformation("Request completed with status code: {StatusCode}", httpContext.Response.StatusCode);
        _logger.LogError("Something went wrong: {Exception}", exception);
        var errorDetails = new ErrorDetailsResponseModel();

        switch (exception)
        {
            case ConflictException _:
                httpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;
                errorDetails.Message = exception.Message;
                break;
            case NotFoundException _:
                httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                errorDetails.Message = exception.Message;
                break;
            case ForbiddenAccessException _:
                httpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                errorDetails.Message = exception.Message;
                break;
   
            case { } e:
                errorDetails.Message =
                    string.IsNullOrWhiteSpace(e.Message) ? "Error" : "Server error, please try later";
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                break;
        }

        httpContext.Response.ContentType = "application/json";

        var result = JsonSerializer.Serialize(errorDetails);
        await httpContext.Response.WriteAsync(result);
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class ExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseMovieShopExceptionMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<MovieShopExceptionMiddleware>();
    }
}