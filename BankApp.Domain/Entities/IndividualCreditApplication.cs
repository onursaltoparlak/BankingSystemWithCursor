using BankApp.Core.Entities;
using BankApp.Core.Enums;
using BankApp.Domain.Entities.Customers;
using BankApp.Domain.Enums;

namespace BankApp.Domain.Entities;

public class IndividualCreditApplication : BaseEntity<Guid>
{
    public Guid IndividualCustomerId { get; set; }
    public Guid CreditTypeId { get; set; }
    public required string NationalId { get; set; }
    public decimal Amount { get; set; }
    public int TermInMonths { get; set; }
    public decimal MonthlyIncome { get; set; }
    public required string EmployerName { get; set; }
    public required string EmployerPhone { get; set; }
    public CreditApplicationStatus Status { get; set; }
    public decimal MonthlyPayment { get; set; }
    public string? RejectionReason { get; set; }
    public DateTime ApplicationDate { get; set; }
    public DateTime? EvaluationDate { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public DateTime? RejectionDate { get; set; }

    public required virtual IndividualCustomer IndividualCustomer { get; set; }
    public required virtual CreditType CreditType { get; set; }

    public IndividualCreditApplication()
    {
        IndividualCustomer = null!;
    }
} 