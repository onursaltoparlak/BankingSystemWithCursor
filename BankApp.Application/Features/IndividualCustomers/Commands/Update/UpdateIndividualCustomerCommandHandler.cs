using AutoMapper;
using BankApp.Application.Features.IndividualCustomers.Rules;
using BankApp.Application.Services.Repositories;
using BankApp.Domain.Entities;
using MediatR;

namespace BankApp.Application.Features.IndividualCustomers.Commands.Update;

public class UpdateIndividualCustomerCommandHandler : IRequestHandler<UpdateIndividualCustomerCommand, UpdatedIndividualCustomerResponse>
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;
    private readonly IMapper _mapper;
    private readonly IndividualCustomerBusinessRules _businessRules;

    public UpdateIndividualCustomerCommandHandler(
        IIndividualCustomerRepository individualCustomerRepository,
        IMapper mapper,
        IndividualCustomerBusinessRules businessRules)
    {
        _individualCustomerRepository = individualCustomerRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<UpdatedIndividualCustomerResponse> Handle(UpdateIndividualCustomerCommand request, CancellationToken cancellationToken)
    {
        await _businessRules.IndividualCustomerShouldExistWhenRequested(request.Id);

        var individualCustomer = await _individualCustomerRepository.GetAsync(ic => ic.Id == request.Id);
        individualCustomer = _mapper.Map(request, individualCustomer);

        await _individualCustomerRepository.UpdateAsync(individualCustomer);

        var response = _mapper.Map<UpdatedIndividualCustomerResponse>(individualCustomer);
        return response;
    }
} 