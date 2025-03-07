using BankApp.Domain.Enums;

namespace BankApp.Application.Features.CorporateCreditApplications.Queries.GetById;

public class GetByIdCorporateCreditApplicationResponse
{
    public Guid Id { get; set; }
    public Guid CreditTypeId { get; set; }
    public required string CreditTypeName { get; set; }
    public Guid CorporateCustomerId { get; set; }
    public required string TaxNumber { get; set; }
    public required string CompanyName { get; set; }
    public required string CompanyType { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Email { get; set; }
    public required string Address { get; set; }
    public DateTime EstablishmentDate { get; set; }
    public decimal AnnualRevenue { get; set; }
    public int EmployeeCount { get; set; }
    public string? TradeRegistryNumber { get; set; }
    public decimal RequestedAmount { get; set; }
    public int InstallmentCount { get; set; }
    public decimal MonthlyPayment { get; set; }
    public CreditApplicationStatus Status { get; set; }
    public string? RejectionReason { get; set; }
    public DateTime ApplicationDate { get; set; }
    public DateTime? EvaluationDate { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public DateTime? RejectionDate { get; set; }
} 