using BankApp.Core.Entities;
using BankApp.Domain.Enums;

namespace BankApp.Domain.Entities;

public abstract class CreditApplication : Entity<CreditApplication>
{
    public Guid CreditTypeId { get; set; }
    public CreditType CreditType { get; set; }
    public decimal Amount { get; set; }
    public int TermInMonths { get; set; }
    public CreditApplicationStatus Status { get; set; }
    public string? Notes { get; set; }

    protected CreditApplication()
    {
        CreditType = null!;
        Status = CreditApplicationStatus.Pending;
    }
} 