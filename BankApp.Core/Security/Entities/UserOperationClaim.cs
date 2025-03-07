namespace BankApp.Core.Security.Entities;

public class UserOperationClaim
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid OperationClaimId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public virtual User User { get; set; }
    public virtual OperationClaim OperationClaim { get; set; }
} 