using System.Net;
using System.Text.Json;

namespace WebApi.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
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
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred: {Message}", ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        var response = new ErrorResponse();

        switch (exception)
        {
            case Domain.Exceptions.NotFoundException ex:
                response.Message = ex.Message;
                response.StatusCode = (int)HttpStatusCode.NotFound;
                response.Details = "The requested resource was not found";
                break;

            case ArgumentException ex:
                response.Message = ex.Message;
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Details = "Invalid parameter provided";
                break;

            case UnauthorizedAccessException:
                response.Message = "Access denied";
                response.StatusCode = (int)HttpStatusCode.Unauthorized;
                response.Details = "You do not have permission to access this resource";
                break;

            case System.Security.Authentication.AuthenticationException:
                response.Message = "Authentication failed";
                response.StatusCode = (int)HttpStatusCode.Unauthorized;
                response.Details = "Invalid credentials provided";
                break;

            case KeyNotFoundException:
                response.Message = "Resource not found";
                response.StatusCode = (int)HttpStatusCode.NotFound;
                response.Details = "The requested resource was not found";
                break;

            case InvalidOperationException ex:
                response.Message = ex.Message;
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Details = "Invalid operation";
                break;

            case TimeoutException:
                response.Message = "Operation timeout exceeded";
                response.StatusCode = (int)HttpStatusCode.RequestTimeout;
                response.Details = "The operation took too long to complete";
                break;

            default:
                response.Message = "Internal server error";
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                response.Details = "An unexpected error occurred on the server";
                break;
        }

        context.Response.StatusCode = response.StatusCode;

        var jsonResponse = JsonSerializer.Serialize(response, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        await context.Response.WriteAsync(jsonResponse);
    }
}

public class ErrorResponse
{
    public string Message { get; set; }
    public int StatusCode { get; set; }
    public string Details { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}