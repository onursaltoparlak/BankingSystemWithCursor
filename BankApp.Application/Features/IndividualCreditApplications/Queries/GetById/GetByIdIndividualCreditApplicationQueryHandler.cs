using BankApp.Application.Repositories;
using BankApp.Domain.Entities;
using BankApp.Domain.Enums;
using MediatR;
using BankApp.Core.CrossCuttingConcerns.Exceptions;

namespace BankApp.Application.Features.IndividualCreditApplications.Queries.GetById;

public class GetByIdIndividualCreditApplicationQueryHandler : IRequestHandler<GetByIdIndividualCreditApplicationQuery, GetByIdIndividualCreditApplicationResponse>
{
    private readonly IIndividualCreditApplicationRepository _individualCreditApplicationRepository;

    public GetByIdIndividualCreditApplicationQueryHandler(IIndividualCreditApplicationRepository individualCreditApplicationRepository)
    {
        _individualCreditApplicationRepository = individualCreditApplicationRepository;
    }

    public async Task<GetByIdIndividualCreditApplicationResponse> Handle(GetByIdIndividualCreditApplicationQuery request, CancellationToken cancellationToken)
    {
        var application = await _individualCreditApplicationRepository.GetAsync(ica => ica.Id == request.Id);
        if (application == null)
            throw new BusinessException("Kredi başvurusu bulunamadı.");

        return new GetByIdIndividualCreditApplicationResponse
        {
            Id = application.Id,
            CreditTypeId = application.CreditTypeId,
            CreditTypeName = application.CreditType.Name,
            IndividualCustomerId = application.IndividualCustomerId,
            NationalId = application.NationalId,
            FirstName = application.IndividualCustomer.FirstName,
            LastName = application.IndividualCustomer.LastName,
            DateOfBirth = application.IndividualCustomer.DateOfBirth,
            PhoneNumber = application.IndividualCustomer.PhoneNumber,
            Email = application.IndividualCustomer.Email,
            Address = application.IndividualCustomer.Address,
            MonthlyIncome = application.MonthlyIncome,
            EmployerName = application.EmployerName,
            EmployerPhone = application.EmployerPhone,
            Amount = application.Amount,
            TermInMonths = application.TermInMonths,
            MonthlyPayment = application.MonthlyPayment,
            Status = (Domain.Enums.CreditApplicationStatus)(int)application.Status,
            RejectionReason = application.RejectionReason,
            ApplicationDate = application.ApplicationDate,
            EvaluationDate = application.EvaluationDate,
            ApprovalDate = application.ApprovalDate,
            RejectionDate = application.RejectionDate
        };
    }
} 