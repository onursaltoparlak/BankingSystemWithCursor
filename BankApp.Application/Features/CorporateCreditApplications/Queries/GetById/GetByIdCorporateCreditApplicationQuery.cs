using MediatR;

namespace BankApp.Application.Features.CorporateCreditApplications.Queries.GetById;

public class GetByIdCorporateCreditApplicationQuery : IRequest<GetByIdCorporateCreditApplicationResponse>
{
    public Guid Id { get; set; }
} 