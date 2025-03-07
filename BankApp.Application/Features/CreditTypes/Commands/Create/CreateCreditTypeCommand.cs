using MediatR;

namespace BankApp.Application.Features.CreditTypes.Commands.Create;

public class CreateCreditTypeCommand : IRequest<CreatedCreditTypeResponse>
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal MinAmount { get; set; }
    public decimal MaxAmount { get; set; }
    public decimal MinInterestRate { get; set; }
    public decimal MaxInterestRate { get; set; }
    public int MinTermInMonths { get; set; }
    public int MaxTermInMonths { get; set; }
    public bool IsActive { get; set; }
} 