using AutoMapper;
using BankApp.Application.Features.CorporateCreditApplications.Commands.Create;
using BankApp.Application.Features.CorporateCreditApplications.Queries.GetById;
using BankApp.Application.Features.CorporateCreditApplications.Queries.GetList;
using BankApp.Domain.Entities;

namespace BankApp.Application.Features.CorporateCreditApplications.Profiles;

public class CorporateCreditApplicationMappingProfiles : Profile
{
    public CorporateCreditApplicationMappingProfiles()
    {
        CreateMap<CorporateCreditApplication, GetListCorporateCreditApplicationListItemDto>();
        CreateMap<CorporateCreditApplication, GetByIdCorporateCreditApplicationResponse>();
        CreateMap<CorporateCreditApplication, CreatedCorporateCreditApplicationResponse>();
        CreateMap<CreateCorporateCreditApplicationCommand, CorporateCreditApplication>();
    }
} 