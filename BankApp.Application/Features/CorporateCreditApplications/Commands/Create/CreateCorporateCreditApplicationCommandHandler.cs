using AutoMapper;
using BankApp.Application.Features.CorporateCreditApplications.Rules;
using BankApp.Application.Services.Repositories;
using BankApp.Domain.Enums;
using BankApp.Domain.Entities;
using MediatR;

namespace BankApp.Application.Features.CorporateCreditApplications.Commands.Create;

public class CreateCorporateCreditApplicationCommandHandler : IRequestHandler<CreateCorporateCreditApplicationCommand, CreatedCorporateCreditApplicationResponse>
{
    private readonly ICorporateCreditApplicationRepository _corporateCreditApplicationRepository;
    private readonly ICorporateCustomerRepository _corporateCustomerRepository;
    private readonly ICreditTypeRepository _creditTypeRepository;
    private readonly IMapper _mapper;
    private readonly CorporateCreditApplicationBusinessRules _businessRules;

    public CreateCorporateCreditApplicationCommandHandler(
        ICorporateCreditApplicationRepository corporateCreditApplicationRepository,
        ICorporateCustomerRepository corporateCustomerRepository,
        ICreditTypeRepository creditTypeRepository,
        IMapper mapper,
        CorporateCreditApplicationBusinessRules businessRules)
    {
        _corporateCreditApplicationRepository = corporateCreditApplicationRepository;
        _corporateCustomerRepository = corporateCustomerRepository;
        _creditTypeRepository = creditTypeRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<CreatedCorporateCreditApplicationResponse> Handle(CreateCorporateCreditApplicationCommand request, CancellationToken cancellationToken)
    {
        await _businessRules.CorporateCustomerShouldExistWhenApplicationCreated(request.CorporateCustomerId);
        await _businessRules.CreditTypeShouldExistWhenApplicationCreated(request.CreditTypeId);

        var corporateCreditApplication = new CorporateCreditApplication
        {
            CorporateCustomerId = request.CorporateCustomerId,
            CreditTypeId = request.CreditTypeId,
            Amount = request.Amount,
            TermInMonths = request.TermInMonths,
            AnnualRevenue = request.AnnualRevenue,
            EmployeeCount = request.EmployeeCount,
            TradeRegistryNumber = request.TradeRegistryNumber,
            Status = CreditApplicationStatus.Pending,
            MonthlyPayment = request.Amount / request.TermInMonths,
            ApplicationDate = DateTime.UtcNow,
            TaxNumber = request.TaxNumber,
            CompanyName = request.CompanyName,
            CompanyType = request.CompanyType,
            EstablishmentDate = request.EstablishmentDate,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            Address = request.Address
        };

        await _corporateCreditApplicationRepository.AddAsync(corporateCreditApplication);

        var response = _mapper.Map<CreatedCorporateCreditApplicationResponse>(corporateCreditApplication);
        return response;
    }
} 