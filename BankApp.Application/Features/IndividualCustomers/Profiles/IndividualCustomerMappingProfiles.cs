using AutoMapper;
using BankApp.Application.Features.IndividualCustomers.Queries.GetList;
using BankApp.Domain.Entities;

namespace BankApp.Application.Features.IndividualCustomers.Profiles;

public class IndividualCustomerMappingProfiles : Profile
{
    public IndividualCustomerMappingProfiles()
    {
        CreateMap<IndividualCustomer, GetListIndividualCustomerListItemDto>();
    }
} 