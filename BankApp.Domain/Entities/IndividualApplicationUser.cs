namespace BankApp.Domain.Entities;

public class IndividualApplicationUser : ApplicationUser
{
    public new required string FirstName { get; set; }
    public new required string LastName { get; set; }
} 