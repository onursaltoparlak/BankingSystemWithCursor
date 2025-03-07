using MediatR;

namespace BankApp.Application.Features.IndividualCreditApplications.Commands.Create;

public class CreateIndividualCreditApplicationCommand : IRequest<CreatedIndividualCreditApplicationResponse>
{
    public Guid CreditTypeId { get; set; }
    public Guid IndividualCustomerId { get; set; }
    public required string NationalId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Email { get; set; }
    public required string Address { get; set; }
    public decimal MonthlyIncome { get; set; }
    public string? EmployerName { get; set; }
    public string? EmployerPhone { get; set; }
    public decimal Amount { get; set; }
    public int TermInMonths { get; set; }
} 