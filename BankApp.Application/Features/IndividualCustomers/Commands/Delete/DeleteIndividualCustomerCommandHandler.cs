using AutoMapper;
using BankApp.Application.Features.IndividualCustomers.Rules;
using BankApp.Application.Services.Repositories;
using MediatR;

namespace BankApp.Application.Features.IndividualCustomers.Commands.Delete;

public class DeleteIndividualCustomerCommandHandler : IRequestHandler<DeleteIndividualCustomerCommand, DeletedIndividualCustomerResponse>
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;
    private readonly IMapper _mapper;
    private readonly IndividualCustomerBusinessRules _businessRules;

    public DeleteIndividualCustomerCommandHandler(
        IIndividualCustomerRepository individualCustomerRepository,
        IMapper mapper,
        IndividualCustomerBusinessRules businessRules)
    {
        _individualCustomerRepository = individualCustomerRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<DeletedIndividualCustomerResponse> Handle(DeleteIndividualCustomerCommand request, CancellationToken cancellationToken)
    {
        await _businessRules.IndividualCustomerShouldExistWhenRequested(request.Id);

        var individualCustomer = await _individualCustomerRepository.GetAsync(ic => ic.Id == request.Id);
        await _individualCustomerRepository.DeleteAsync(individualCustomer);

        var response = _mapper.Map<DeletedIndividualCustomerResponse>(individualCustomer);
        return response;
    }
} 