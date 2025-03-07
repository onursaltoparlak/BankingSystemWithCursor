using BankApp.Domain.Entities;
using BankApp.Domain.Repositories;
using MediatR;

namespace BankApp.Application.Features.Loans.Commands.CreateLoan;

public class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand, Guid>
{
    private readonly ILoanRepository _loanRepository;

    public CreateLoanCommandHandler(ILoanRepository loanRepository)
    {
        _loanRepository = loanRepository;
    }

    public async Task<Guid> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
    {
        var loan = new Loan
        {
            Amount = request.Amount,
            InterestRate = request.InterestRate,
            Term = request.Term,
            CustomerId = request.CustomerId
        };

        await _loanRepository.AddAsync(loan);
        return loan.Id;
    }
} 