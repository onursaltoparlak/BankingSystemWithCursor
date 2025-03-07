using BankApp.Core.CrossCuttingConcerns.Exceptions.Types;
using System.Net;
using System.Text.Json;

namespace BankApp.WebApi.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
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

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        if (exception is BusinessException businessException)
        {
            return CreateBusinessProblemDetails(context, businessException);
        }

        return CreateInternalProblemDetails(context, exception);
    }

    private Task CreateBusinessProblemDetails(HttpContext context, BusinessException businessException)
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        var details = new BusinessProblemDetails
        {
            Status = (int)HttpStatusCode.BadRequest,
            Type = "https://example.com/probs/business",
            Title = "Business exception",
            Detail = businessException.Message,
            Instance = ""
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(details));
    }

    private Task CreateInternalProblemDetails(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var details = new ProblemDetails
        {
            Status = (int)HttpStatusCode.InternalServerError,
            Type = "https://example.com/probs/internal",
            Title = "Internal exception",
            Detail = exception.Message,
            Instance = ""
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(details));
    }
}

public class BusinessProblemDetails : ProblemDetails
{
    public string[] Errors { get; set; } = Array.Empty<string>();
}

public class ProblemDetails
{
    public string Type { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Detail { get; set; } = string.Empty;
    public string Instance { get; set; } = string.Empty;
    public int Status { get; set; }
} 