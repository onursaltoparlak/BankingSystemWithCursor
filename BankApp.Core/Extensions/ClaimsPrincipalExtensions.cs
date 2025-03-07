using System.Security.Claims;

namespace BankApp.Core.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static List<string> ClaimRoles(this ClaimsPrincipal principal)
    {
        return principal?.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).ToList() ?? new List<string>();
    }
} 