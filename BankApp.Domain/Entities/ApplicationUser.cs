using BankApp.Core.Security.Entities;

namespace BankApp.Domain.Entities;

public abstract class ApplicationUser : User
{
    public required string PhoneNumber { get; set; }
    public required string Address { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public Guid CustomerId { get; set; }

    public virtual Customer Customer { get; set; }
} 