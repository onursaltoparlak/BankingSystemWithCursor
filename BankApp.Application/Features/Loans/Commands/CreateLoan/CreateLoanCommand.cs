using MediatR;

namespace BankApp.Application.Features.Loans.Commands.CreateLoan;

public class CreateLoanCommand : IRequest<Guid>
{
    public decimal Amount { get; set; }
    public decimal InterestRate { get; set; }
    public int Term { get; set; }
    public Guid CustomerId { get; set; }
} 