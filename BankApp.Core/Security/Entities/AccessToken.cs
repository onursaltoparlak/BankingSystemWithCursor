namespace BankApp.Core.Security.Entities;

public class AccessToken
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
} 