using Application.Commons.Mediator;
using Application.Regions.Entities;
using AutoMapper;

namespace Application.Regions.Features.GetCountryCodes;

public class GetAllCountryCodesMapper : Profile
{
    public GetAllCountryCodesMapper()
    {
        CreateMap<CountryCode, IdValueDto>();

        CreateMap<List<CountryCode>, IdValueListResponse>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src));
    }
}