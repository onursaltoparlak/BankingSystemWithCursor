namespace BankApp.Core.Security.DTOs;

public class UserForLoginDto
{
    public required string Email { get; set; }
    public required string Password { get; set; }
} 