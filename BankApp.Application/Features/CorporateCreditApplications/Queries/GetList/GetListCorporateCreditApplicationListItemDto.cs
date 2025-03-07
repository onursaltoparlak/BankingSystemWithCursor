using BankApp.Domain.Enums;

namespace BankApp.Application.Features.CorporateCreditApplications.Queries.GetList;

public class GetListCorporateCreditApplicationListItemDto
{
    public Guid Id { get; set; }
    public Guid CorporateCustomerId { get; set; }
    public required string CompanyName { get; set; }
    public required string TaxNumber { get; set; }
    public Guid CreditTypeId { get; set; }
    public required string CreditTypeName { get; set; }
    public decimal Amount { get; set; }
    public int TermInMonths { get; set; }
    public CreditApplicationStatus Status { get; set; }
    public DateTime CreatedDate { get; set; }
} 