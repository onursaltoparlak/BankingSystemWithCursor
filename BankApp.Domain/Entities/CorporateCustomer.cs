using BankApp.Core.Entities;
using BankApp.Core.Enums;

namespace BankApp.Domain.Entities;

public class CorporateCustomer : Customer
{
    public required string CompanyName { get; set; }
    public required string TaxNumber { get; set; }
    public required string TaxOffice { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Address { get; set; }
    public int EmployeeCount { get; set; }
    public decimal AnnualRevenue { get; set; }
    public DateTime EstablishmentDate { get; set; }
    public CompanyType CompanyType { get; set; }

    // Navigation Properties
    public virtual new CorporateApplicationUser ApplicationUser { get; set; }
    public virtual ICollection<CorporateCreditApplication> CreditApplications { get; set; }

    public CorporateCustomer()
    {
        CreditApplications = new HashSet<CorporateCreditApplication>();
    }
} 