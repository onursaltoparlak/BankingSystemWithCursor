using Microsoft.AspNetCore.Builder;

namespace BankApp.WebApi.Middleware;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<HttpExceptionHandlerMiddleware>();
    }
} 