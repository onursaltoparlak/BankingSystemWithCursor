using MediatR;

namespace BankApp.Application.Features.CreditTypes.Commands.Delete;

public class DeleteCreditTypeCommand : IRequest<DeletedCreditTypeResponse>
{
    public Guid Id { get; set; }
} 