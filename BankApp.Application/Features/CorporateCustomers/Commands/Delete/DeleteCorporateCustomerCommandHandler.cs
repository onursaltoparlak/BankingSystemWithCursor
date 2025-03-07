using BankApp.Application.Features.CorporateCustomers.Rules;
using BankApp.Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace BankApp.Application.Features.CorporateCustomers.Commands.Delete;

public class DeleteCorporateCustomerCommandHandler : IRequestHandler<DeleteCorporateCustomerCommand, DeletedCorporateCustomerResponse>
{
    private readonly ICorporateCustomerRepository _corporateCustomerRepository;
    private readonly IMapper _mapper;
    private readonly CorporateCustomerBusinessRules _corporateCustomerBusinessRules;

    public DeleteCorporateCustomerCommandHandler(ICorporateCustomerRepository corporateCustomerRepository, IMapper mapper,
                                               CorporateCustomerBusinessRules corporateCustomerBusinessRules)
    {
        _corporateCustomerRepository = corporateCustomerRepository;
        _mapper = mapper;
        _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
    }

    public async Task<DeletedCorporateCustomerResponse> Handle(DeleteCorporateCustomerCommand request, CancellationToken cancellationToken)
    {
        await _corporateCustomerBusinessRules.CorporateCustomerIdShouldExistWhenSelected(request.Id, cancellationToken);

        var corporateCustomer = await _corporateCustomerRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
        var deletedCorporateCustomer = await _corporateCustomerRepository.DeleteAsync(corporateCustomer!, cancellationToken);
        var response = _mapper.Map<DeletedCorporateCustomerResponse>(deletedCorporateCustomer);

        return response;
    }
} 