using MediatR;

namespace BankApp.Application.Features.CreditTypes.Queries.GetById;

public class GetByIdCreditTypeQuery : IRequest<GetByIdCreditTypeResponse>
{
    public Guid Id { get; set; }
} 