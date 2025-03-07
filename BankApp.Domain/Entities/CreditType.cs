using BankApp.Core.Entities;
using BankApp.Core.Enums;

namespace BankApp.Domain.Entities;

public class CreditType : BaseEntity<Guid>
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal MinAmount { get; set; }
    public decimal MaxAmount { get; set; }
    public decimal MinInterestRate { get; set; }
    public decimal MaxInterestRate { get; set; }
    public int MinTermInMonths { get; set; }
    public int MaxTermInMonths { get; set; }
    public bool IsActive { get; set; }
    public CreditTypeCategory Category { get; set; }

    public virtual ICollection<IndividualCreditApplication> IndividualCreditApplications { get; set; }
    public virtual ICollection<CorporateCreditApplication> CorporateCreditApplications { get; set; }

    public CreditType()
    {
        IndividualCreditApplications = new HashSet<IndividualCreditApplication>();
        CorporateCreditApplications = new HashSet<CorporateCreditApplication>();
    }
} 