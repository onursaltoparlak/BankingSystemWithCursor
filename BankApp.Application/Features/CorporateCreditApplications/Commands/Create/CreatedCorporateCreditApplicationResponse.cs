using BankApp.Domain.Entities;

namespace BankApp.Application.Features.CorporateCreditApplications.Commands.Create;

public class CreatedCorporateCreditApplicationResponse
{
    public Guid Id { get; set; }
    public Guid CreditTypeId { get; set; }
    public Guid CorporateCustomerId { get; set; }
    public decimal Amount { get; set; }
    public decimal MonthlyPayment { get; set; }
    public int Term { get; set; }
    public required string TaxNumber { get; set; }
    public required string CompanyName { get; set; }
    public DateTime CreatedDate { get; set; }
} 