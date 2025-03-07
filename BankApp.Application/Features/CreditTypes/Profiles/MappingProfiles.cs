using AutoMapper;
using BankApp.Application.Features.CreditTypes.Commands.Create;
using BankApp.Application.Features.CreditTypes.Commands.Delete;
using BankApp.Application.Features.CreditTypes.Commands.Update;
using BankApp.Application.Features.CreditTypes.Queries.GetById;
using BankApp.Application.Features.CreditTypes.Queries.GetList;
using BankApp.Core.Application.Responses;
using BankApp.Core.Persistence.Paging;
using BankApp.Domain.Entities;

namespace BankApp.Application.Features.CreditTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreditType, CreateCreditTypeCommand>().ReverseMap();
        CreateMap<CreditType, CreatedCreditTypeResponse>().ReverseMap();
        CreateMap<CreditType, UpdateCreditTypeCommand>().ReverseMap();
        CreateMap<CreditType, UpdatedCreditTypeResponse>().ReverseMap();
        CreateMap<CreditType, DeleteCreditTypeCommand>().ReverseMap();
        CreateMap<CreditType, DeletedCreditTypeResponse>().ReverseMap();
        CreateMap<CreditType, GetByIdCreditTypeResponse>().ReverseMap();
        CreateMap<CreditType, GetListCreditTypeListItemDto>().ReverseMap();
        CreateMap<IPaginate<CreditType>, GetListResponse<GetListCreditTypeListItemDto>>().ReverseMap();
    }
} 