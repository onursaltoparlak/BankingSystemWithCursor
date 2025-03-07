using AutoMapper;
using BankApp.Application.Features.IndividualCreditApplications.Rules;
using BankApp.Application.Services.Repositories;
using BankApp.Domain.Enums;
using BankApp.Domain.Entities;
using MediatR;

namespace BankApp.Application.Features.IndividualCreditApplications.Commands.Create;

public class CreateIndividualCreditApplicationCommandHandler : IRequestHandler<CreateIndividualCreditApplicationCommand, CreatedIndividualCreditApplicationResponse>
{
    private readonly IIndividualCreditApplicationRepository _individualCreditApplicationRepository;
    private readonly IIndividualCustomerRepository _individualCustomerRepository;
    private readonly ICreditTypeRepository _creditTypeRepository;
    private readonly IMapper _mapper;
    private readonly IndividualCreditApplicationBusinessRules _businessRules;

    public CreateIndividualCreditApplicationCommandHandler(
        IIndividualCreditApplicationRepository individualCreditApplicationRepository,
        IIndividualCustomerRepository individualCustomerRepository,
        ICreditTypeRepository creditTypeRepository,
        IMapper mapper,
        IndividualCreditApplicationBusinessRules businessRules)
    {
        _individualCreditApplicationRepository = individualCreditApplicationRepository;
        _individualCustomerRepository = individualCustomerRepository;
        _creditTypeRepository = creditTypeRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<CreatedIndividualCreditApplicationResponse> Handle(CreateIndividualCreditApplicationCommand request, CancellationToken cancellationToken)
    {
        await _businessRules.IndividualCustomerShouldExistWhenApplicationCreated(request.IndividualCustomerId);
        await _businessRules.CreditTypeShouldExistWhenApplicationCreated(request.CreditTypeId);

        var individualCustomer = await _individualCustomerRepository.GetAsync(ic => ic.Id == request.IndividualCustomerId);
        var creditType = await _creditTypeRepository.GetAsync(ct => ct.Id == request.CreditTypeId);

        var individualCreditApplication = new IndividualCreditApplication
        {
            IndividualCustomerId = request.IndividualCustomerId,
            CreditTypeId = request.CreditTypeId,
            NationalId = request.NationalId,
            Amount = request.Amount,
            TermInMonths = request.TermInMonths,
            MonthlyIncome = request.MonthlyIncome,
            EmployerName = request.EmployerName,
            EmployerPhone = request.EmployerPhone,
            Status = CreditApplicationStatus.Pending,
            MonthlyPayment = request.Amount / request.TermInMonths,
            ApplicationDate = DateTime.UtcNow,
            IndividualCustomer = individualCustomer,
            CreditType = creditType
        };

        await _individualCreditApplicationRepository.AddAsync(individualCreditApplication);

        var response = _mapper.Map<CreatedIndividualCreditApplicationResponse>(individualCreditApplication);
        return response;
    }
} 