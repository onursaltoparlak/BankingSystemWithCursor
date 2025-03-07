namespace BankApp.Core.Entities;

public abstract class Entity<TEntity> where TEntity : Entity<TEntity>
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
        CreatedDate = DateTime.UtcNow;
    }
} 