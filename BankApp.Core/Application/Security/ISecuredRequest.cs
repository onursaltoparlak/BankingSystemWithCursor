namespace BankApp.Core.Application.Security;

public interface ISecuredRequest
{
    string[] Roles { get; }
} 