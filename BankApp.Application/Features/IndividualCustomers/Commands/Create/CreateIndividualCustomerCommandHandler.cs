using AutoMapper;
using BankApp.Application.Services.Repositories;
using BankApp.Domain.Entities;
using MediatR;

namespace BankApp.Application.Features.IndividualCustomers.Commands.Create;

public class CreateIndividualCustomerCommandHandler : IRequestHandler<CreateIndividualCustomerCommand, CreatedIndividualCustomerResponse>
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;
    private readonly IMapper _mapper;

    public CreateIndividualCustomerCommandHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper)
    {
        _individualCustomerRepository = individualCustomerRepository;
        _mapper = mapper;
    }

    public async Task<CreatedIndividualCustomerResponse> Handle(CreateIndividualCustomerCommand request, CancellationToken cancellationToken)
    {
        // Create ApplicationUser
        var applicationUser = new IndividualApplicationUser
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            PhoneNumber = request.PhoneNumber,
            Address = request.Address
        };

        // Create IndividualCustomer
        var individualCustomer = new IndividualCustomer
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            NationalId = request.NationalId,
            Email = request.Email,
            DateOfBirth = request.DateOfBirth,
            MonthlyIncome = request.MonthlyIncome,
            PhoneNumber = request.PhoneNumber,
            Address = request.Address,
            IsActive = true,
            ApplicationUser = applicationUser
        };

        // Save to database
        await _individualCustomerRepository.AddAsync(individualCustomer, cancellationToken);

        // Map to response
        var response = _mapper.Map<CreatedIndividualCustomerResponse>(individualCustomer);
        return response;
    }
} 