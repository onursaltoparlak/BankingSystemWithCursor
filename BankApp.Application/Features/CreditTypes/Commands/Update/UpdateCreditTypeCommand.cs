using MediatR;

namespace BankApp.Application.Features.CreditTypes.Commands.Update;

public class UpdateCreditTypeCommand : IRequest<UpdatedCreditTypeResponse>
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal MinAmount { get; set; }
    public decimal MaxAmount { get; set; }
    public int MinTermInMonths { get; set; }
    public int MaxTermInMonths { get; set; }
    public decimal InterestRate { get; set; }
    public bool IsActive { get; set; }
} 