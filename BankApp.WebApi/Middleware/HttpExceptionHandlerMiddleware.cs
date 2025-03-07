using System.Net;
using System.Text.Json;
using BankApp.Core.CrossCuttingConcerns.Exceptions;

namespace BankApp.WebApi.Middleware;

public class HttpExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<HttpExceptionHandlerMiddleware> _logger;

    public HttpExceptionHandlerMiddleware(RequestDelegate next, ILogger<HttpExceptionHandlerMiddleware> logger)
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
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = context.Response;
        response.ContentType = "application/json";

        response.StatusCode = exception switch
        {
            BusinessException => (int)HttpStatusCode.BadRequest,
            ValidationException => (int)HttpStatusCode.BadRequest,
            AuthorizationException => (int)HttpStatusCode.Forbidden,
            _ => (int)HttpStatusCode.InternalServerError
        };

        var result = JsonSerializer.Serialize(new
        {
            StatusCode = response.StatusCode,
            Message = exception.Message,
            Errors = exception is ValidationException validationException ? validationException.Errors : null
        });

        _logger.LogError(exception, "An error occurred: {Message}", exception.Message);
        await response.WriteAsync(result);
    }
} 