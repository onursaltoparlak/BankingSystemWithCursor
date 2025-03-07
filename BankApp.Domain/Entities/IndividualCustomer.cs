using BankApp.Core.Entities;

namespace BankApp.Domain.Entities;

public class IndividualCustomer : Customer
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string NationalId { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Address { get; set; }
    public DateTime DateOfBirth { get; set; }
    public decimal MonthlyIncome { get; set; }

    // Navigation Properties
    public virtual new IndividualApplicationUser ApplicationUser { get; set; }
    public virtual ICollection<IndividualCreditApplication> CreditApplications { get; set; }

    public IndividualCustomer()
    {
        CreditApplications = new HashSet<IndividualCreditApplication>();
    }
} 