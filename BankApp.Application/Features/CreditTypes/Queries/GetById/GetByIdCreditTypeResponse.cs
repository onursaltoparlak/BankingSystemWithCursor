using BankApp.Core.Enums;

namespace BankApp.Application.Features.CreditTypes.Queries.GetById;

public class GetByIdCreditTypeResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal MinAmount { get; set; }
    public decimal MaxAmount { get; set; }
    public int MinTerm { get; set; }
    public int MaxTerm { get; set; }
    public decimal InterestRate { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsActive { get; set; }
    public CreditTypeCategory Category { get; set; }
} 