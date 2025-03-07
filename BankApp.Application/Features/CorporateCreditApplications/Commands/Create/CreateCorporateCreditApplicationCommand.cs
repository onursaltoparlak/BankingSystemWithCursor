using MediatR;

namespace BankApp.Application.Features.CorporateCreditApplications.Commands.Create;

public class CreateCorporateCreditApplicationCommand : IRequest<CreatedCorporateCreditApplicationResponse>
{
    public Guid CreditTypeId { get; set; }
    public Guid CorporateCustomerId { get; set; }
    public required string TaxNumber { get; set; }
    public required string CompanyName { get; set; }
    public required string CompanyType { get; set; }
    public DateTime EstablishmentDate { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Email { get; set; }
    public required string Address { get; set; }
    public decimal AnnualRevenue { get; set; }
    public int EmployeeCount { get; set; }
    public string? TradeRegistryNumber { get; set; }
    public decimal Amount { get; set; }
    public int TermInMonths { get; set; }
} 