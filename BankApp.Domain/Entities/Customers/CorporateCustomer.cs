using BankApp.Core.Entities;

namespace BankApp.Domain.Entities.Customers;

public class CorporateCustomer : Entity<CorporateCustomer>
{
    public string CompanyName { get; set; }
    public string TaxNumber { get; set; }
    public string TaxOffice { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public bool IsActive { get; set; }

    public CorporateCustomer()
    {
        CompanyName = null!;
        TaxNumber = null!;
        TaxOffice = null!;
        Email = null!;
        Phone = null!;
        Address = null!;
        IsActive = true;
    }
} 