using BankApp.Application.Features.Loans.DTOs;
using MediatR;

namespace BankApp.Application.Features.Loans.Queries.GetLoanById;

public class GetLoanByIdQuery : IRequest<LoanDto>
{
    public Guid Id { get; set; }
} 