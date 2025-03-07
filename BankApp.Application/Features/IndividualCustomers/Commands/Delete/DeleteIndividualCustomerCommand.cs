using MediatR;

namespace BankApp.Application.Features.IndividualCustomers.Commands.Delete;

public class DeleteIndividualCustomerCommand : IRequest<DeletedIndividualCustomerResponse>
{
    public required Guid Id { get; set; }
} 