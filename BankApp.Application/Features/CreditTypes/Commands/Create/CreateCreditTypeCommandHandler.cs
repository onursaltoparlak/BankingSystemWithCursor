using AutoMapper;
using BankApp.Domain.Entities;
using BankApp.Domain.Repositories;
using MediatR;

namespace BankApp.Application.Features.CreditTypes.Commands.Create;

public class CreateCreditTypeCommandHandler : IRequestHandler<CreateCreditTypeCommand, CreatedCreditTypeResponse>
{
    private readonly ICreditTypeRepository _creditTypeRepository;
    private readonly IMapper _mapper;

    public CreateCreditTypeCommandHandler(ICreditTypeRepository creditTypeRepository, IMapper mapper)
    {
        _creditTypeRepository = creditTypeRepository;
        _mapper = mapper;
    }

    public async Task<CreatedCreditTypeResponse> Handle(CreateCreditTypeCommand request, CancellationToken cancellationToken)
    {
        var creditType = new CreditType
        {
            Name = request.Name,
            Description = request.Description,
            MinAmount = request.MinAmount,
            MaxAmount = request.MaxAmount,
            MinInterestRate = request.MinInterestRate,
            MaxInterestRate = request.MaxInterestRate,
            MinTermInMonths = request.MinTermInMonths,
            MaxTermInMonths = request.MaxTermInMonths,
            IsActive = request.IsActive
        };

        await _creditTypeRepository.AddAsync(creditType);
        var response = _mapper.Map<CreatedCreditTypeResponse>(creditType);
        return response;
    }
} 