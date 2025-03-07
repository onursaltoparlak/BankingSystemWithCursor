namespace BankApp.Application.Features.IndividualCustomers.Commands.Create;

public class CreatedIndividualCustomerResponse
{
    public Guid Id { get; set; }
    public Guid ApplicationUserId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string NationalId { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Address { get; set; }
    public DateTime DateOfBirth { get; set; }
    public decimal MonthlyIncome { get; set; }
    public DateTime CreatedDate { get; set; }
} 