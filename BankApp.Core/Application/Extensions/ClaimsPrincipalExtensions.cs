using System.Security.Claims;

namespace BankApp.Core.Application.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static string[] ClaimRoles(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal?.FindAll(ClaimTypes.Role).Select(x => x.Value).ToArray();
    }
} 