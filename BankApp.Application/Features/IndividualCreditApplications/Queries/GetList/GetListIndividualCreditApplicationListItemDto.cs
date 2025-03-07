using BankApp.Domain.Enums;

namespace BankApp.Application.Features.IndividualCreditApplications.Queries.GetList;

public class GetListIndividualCreditApplicationListItemDto
{
    public Guid Id { get; set; }
    public required string NationalId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Email { get; set; }
    public required string Address { get; set; }
    public decimal Amount { get; set; }
    public int Term { get; set; }
    public decimal MonthlyPayment { get; set; }
    public CreditApplicationStatus Status { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
} 