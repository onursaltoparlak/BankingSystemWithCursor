using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BankApp.WebApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var securityKey = configuration["TokenOptions:SecurityKey"] ?? 
            throw new InvalidOperationException("TokenOptions:SecurityKey is not configured");
        var issuer = configuration["TokenOptions:Issuer"] ?? 
            throw new InvalidOperationException("TokenOptions:Issuer is not configured");
        var audience = configuration["TokenOptions:Audience"] ?? 
            throw new InvalidOperationException("TokenOptions:Audience is not configured");

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = issuer,
                ValidAudience = audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey))
            };
        });

        return services;
    }
} 