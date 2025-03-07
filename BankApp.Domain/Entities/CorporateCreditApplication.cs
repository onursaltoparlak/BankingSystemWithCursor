using BankApp.Core.Entities;
using BankApp.Core.Enums;
using BankApp.Domain.Entities.Customers;
using BankApp.Domain.Enums;

namespace BankApp.Domain.Entities;

public class CorporateCreditApplication : BaseEntity<Guid>
{
    public Guid CorporateCustomerId { get; set; }
    public Guid CreditTypeId { get; set; }
    public decimal Amount { get; set; }
    public int TermInMonths { get; set; }
    public decimal AnnualRevenue { get; set; }
    public int EmployeeCount { get; set; }
    public required string TradeRegistryNumber { get; set; }
    public CreditApplicationStatus Status { get; set; }
    public decimal MonthlyPayment { get; set; }
    public string? RejectionReason { get; set; }
    public DateTime ApplicationDate { get; set; }
    public DateTime? EvaluationDate { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public DateTime? RejectionDate { get; set; }
    public required string TaxNumber { get; set; }
    public required string CompanyName { get; set; }
    public required string CompanyType { get; set; }
    public DateTime EstablishmentDate { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Email { get; set; }
    public required string Address { get; set; }

    public virtual CorporateCustomer CorporateCustomer { get; set; }
    public virtual CreditType CreditType { get; set; }

    public CorporateCreditApplication()
    {
        ApplicationDate = DateTime.UtcNow;
        Status = CreditApplicationStatus.Pending;
    }
} 