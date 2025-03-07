using BankApp.Application.Services.Repositories;
using BankApp.Domain.Entities;
using MediatR;

namespace BankApp.Application.Features.CorporateCustomers.Commands.Update;

public class UpdateCorporateCustomerCommandHandler : IRequestHandler<UpdateCorporateCustomerCommand, UpdatedCorporateCustomerResponse>
{
    private readonly ICorporateCustomerRepository _corporateCustomerRepository;

    public UpdateCorporateCustomerCommandHandler(ICorporateCustomerRepository corporateCustomerRepository)
    {
        _corporateCustomerRepository = corporateCustomerRepository;
    }

    public async Task<UpdatedCorporateCustomerResponse> Handle(UpdateCorporateCustomerCommand request, CancellationToken cancellationToken)
    {
        CorporateCustomer corporateCustomer = await _corporateCustomerRepository.GetAsync(x => x.Id == request.Id);

        corporateCustomer.CompanyName = request.CompanyName;
        corporateCustomer.TaxNumber = request.TaxNumber;
        corporateCustomer.PhoneNumber = request.PhoneNumber;
        corporateCustomer.Address = request.Address;
        corporateCustomer.Email = request.Email;

        await _corporateCustomerRepository.UpdateAsync(corporateCustomer);

        UpdatedCorporateCustomerResponse response = new()
        {
            Id = corporateCustomer.Id,
            CompanyName = corporateCustomer.CompanyName,
            TaxNumber = corporateCustomer.TaxNumber,
            PhoneNumber = corporateCustomer.PhoneNumber,
            Address = corporateCustomer.Address,
            Email = corporateCustomer.Email
        };

        return response;
    }
} 