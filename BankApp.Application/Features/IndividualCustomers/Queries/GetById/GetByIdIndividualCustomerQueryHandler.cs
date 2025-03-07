using AutoMapper;
using BankApp.Application.Features.IndividualCustomers.Rules;
using BankApp.Application.Services.Repositories;
using MediatR;

namespace BankApp.Application.Features.IndividualCustomers.Queries.GetById;

public class GetByIdIndividualCustomerQueryHandler : IRequestHandler<GetByIdIndividualCustomerQuery, GetByIdIndividualCustomerResponse>
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;
    private readonly IndividualCustomerBusinessRules _individualCustomerBusinessRules;
    private readonly IMapper _mapper;

    public GetByIdIndividualCustomerQueryHandler(
        IIndividualCustomerRepository individualCustomerRepository,
        IndividualCustomerBusinessRules individualCustomerBusinessRules,
        IMapper mapper)
    {
        _individualCustomerRepository = individualCustomerRepository;
        _individualCustomerBusinessRules = individualCustomerBusinessRules;
        _mapper = mapper;
    }

    public async Task<GetByIdIndividualCustomerResponse> Handle(GetByIdIndividualCustomerQuery request, CancellationToken cancellationToken)
    {
        await _individualCustomerBusinessRules.IndividualCustomerShouldExistWhenRequested(request.Id);
        
        var individualCustomer = await _individualCustomerRepository.GetAsync(c => c.Id == request.Id);
        var response = _mapper.Map<GetByIdIndividualCustomerResponse>(individualCustomer);
        
        return response;
    }
} 