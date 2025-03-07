using AutoMapper;
using BankApp.Application.Features.CreditTypes.Queries.GetList;
using BankApp.Domain.Entities;

namespace BankApp.Application.Features.CreditTypes.Profiles;

public class CreditTypeMappingProfiles : Profile
{
    public CreditTypeMappingProfiles()
    {
        CreateMap<CreditType, GetListCreditTypeListItemDto>();
    }
} 