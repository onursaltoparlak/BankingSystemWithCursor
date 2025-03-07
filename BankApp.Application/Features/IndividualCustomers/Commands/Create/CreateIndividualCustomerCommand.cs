using MediatR;

namespace BankApp.Application.Features.IndividualCustomers.Commands.Create;

public class CreateIndividualCustomerCommand : IRequest<CreatedIndividualCustomerResponse>
{
    // Customer base properties
    public required string Email { get; set; }

    // Individual Customer specific properties
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string NationalId { get; set; }
    public DateTime DateOfBirth { get; set; }
    public decimal MonthlyIncome { get; set; }

    // Application User properties
    public required string PhoneNumber { get; set; }
    public required string Address { get; set; }
} 