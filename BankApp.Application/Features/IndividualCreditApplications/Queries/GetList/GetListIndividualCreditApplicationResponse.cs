using BankApp.Domain.Entities;

namespace BankApp.Application.Features.IndividualCreditApplications.Queries.GetList;

public class GetListIndividualCreditApplicationResponse
{
    public Guid Id { get; set; }
    public Guid CreditTypeId { get; set; }
    public Guid IndividualCustomerId { get; set; }
    public decimal Amount { get; set; }
    public required string CreditTypeName { get; set; }
    public int Term { get; set; }
    public required string NationalId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime CreatedDate { get; set; }
} 