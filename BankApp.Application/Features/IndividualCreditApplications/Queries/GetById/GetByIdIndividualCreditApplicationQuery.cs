using MediatR;

namespace BankApp.Application.Features.IndividualCreditApplications.Queries.GetById;

public class GetByIdIndividualCreditApplicationQuery : IRequest<GetByIdIndividualCreditApplicationResponse>
{
    public Guid Id { get; set; }
} 