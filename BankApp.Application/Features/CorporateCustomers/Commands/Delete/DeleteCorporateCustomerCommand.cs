using MediatR;

namespace BankApp.Application.Features.CorporateCustomers.Commands.Delete;

public class DeleteCorporateCustomerCommand : IRequest<DeletedCorporateCustomerResponse>
{
    public Guid Id { get; set; }
} 