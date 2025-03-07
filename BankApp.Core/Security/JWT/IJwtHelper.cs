using BankApp.Core.Security.Entities;

namespace BankApp.Core.Security.JWT;

public interface IJwtHelper
{
    AccessToken CreateToken(User user, IList<OperationClaim> operationClaims);
} 