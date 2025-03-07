using BankApp.Domain.Enums;

namespace BankApp.Domain.Entities;

public class Loan : BaseEntity<Guid>
{
    public decimal Amount { get; set; }
    public decimal InterestRate { get; set; }
    public int Term { get; set; }
    public LoanStatus Status { get; set; }
    public Guid CustomerId { get; set; }
    public virtual Customer Customer { get; set; }
    
    public Loan()
    {
        Status = LoanStatus.Pending;
    }
} 