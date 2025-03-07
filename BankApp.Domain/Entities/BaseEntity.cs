using BankApp.Core.Entities;

namespace BankApp.Domain.Entities;

public class BaseEntity<TId> : Entity<BaseEntity<TId>>
{
    public new DateTime CreatedDate { get; set; }
    public new DateTime? UpdatedDate { get; set; }
    public new bool IsDeleted { get; set; }

    protected BaseEntity()
    {
        CreatedDate = DateTime.UtcNow;
    }
} 