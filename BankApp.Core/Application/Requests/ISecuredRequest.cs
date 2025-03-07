namespace BankApp.Core.Application.Requests;

public interface ISecuredRequest
{
    string[] Roles { get; }
} 