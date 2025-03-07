using AutoMapper;
using BankApp.Application.Features.Loans.DTOs;
using BankApp.Domain.Repositories;
using MediatR;

namespace BankApp.Application.Features.Loans.Queries.GetLoanById;

public class GetLoanByIdQueryHandler : IRequestHandler<GetLoanByIdQuery, LoanDto>
{
    private readonly ILoanRepository _loanRepository;
    private readonly IMapper _mapper;

    public GetLoanByIdQueryHandler(ILoanRepository loanRepository, IMapper mapper)
    {
        _loanRepository = loanRepository;
        _mapper = mapper;
    }

    public async Task<LoanDto> Handle(GetLoanByIdQuery request, CancellationToken cancellationToken)
    {
        var loan = await _loanRepository.GetByIdAsync(request.Id, cancellationToken);
        if (loan == null)
            throw new Exception("Loan not found");

        var loanDto = _mapper.Map<LoanDto>(loan);
        return loanDto;
    }
} 