using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Http;
using BankApp.Core.Application.Security;
using BankApp.Core.Extensions;

namespace BankApp.Core.Application.Behaviors;

public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ISecuredRequest
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var userRoleClaims = _httpContextAccessor.HttpContext?.User.ClaimRoles();

        if (userRoleClaims == null)
            throw new Exception("Claims not found.");

        bool isNotMatchedAUserRoleWithRequestRoles = request.Roles.Any(role => !userRoleClaims.Contains(role));
        if (isNotMatchedAUserRoleWithRequestRoles)
            throw new Exception("You are not authorized.");

        var response = await next();
        return response;
    }
} 