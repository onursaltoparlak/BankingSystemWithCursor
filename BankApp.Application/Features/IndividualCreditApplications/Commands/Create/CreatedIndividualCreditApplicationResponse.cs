using BankApp.Domain.Entities;
using BankApp.Domain.Enums;

namespace BankApp.Application.Features.IndividualCreditApplications.Commands.Create;

public class CreatedIndividualCreditApplicationResponse
{
    public Guid Id { get; set; }
    public Guid CreditTypeId { get; set; }
    public Guid IndividualCustomerId { get; set; }
    public required string NationalId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public decimal Amount { get; set; }
    public int TermInMonths { get; set; }
    public decimal MonthlyPayment { get; set; }
    public Domain.Enums.CreditApplicationStatus Status { get; set; }
    public DateTime ApplicationDate { get; set; }
} 