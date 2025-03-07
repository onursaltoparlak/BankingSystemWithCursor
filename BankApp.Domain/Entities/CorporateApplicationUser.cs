namespace BankApp.Domain.Entities;

public class CorporateApplicationUser : ApplicationUser
{
    public required string CompanyName { get; set; }
} 