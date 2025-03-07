using BankApp.Core.Entities;

namespace BankApp.Domain.Entities;

public abstract class Customer : BaseEntity<Guid>
{
    public Guid ApplicationUserId { get; set; }
    public required string Email { get; set; }
    public bool IsActive { get; set; }
    public new DateTime CreatedDate { get; set; }
    public new DateTime? UpdatedDate { get; set; }

    // Navigation Properties
    public virtual ApplicationUser ApplicationUser { get; set; }

    protected Customer()
    {
        CreatedDate = DateTime.UtcNow;
    }
} 