using Application.Commons.Dtos;
using Application.Regions.Entities;
using AutoMapper;

namespace Application.Regions.Features.GetAllCountryCodes;

public class GetAllCountryCodesMapper : Profile
{
    public GetAllCountryCodesMapper()
    {
        CreateMap<CountryCode, GetLibDto>();
        CreateMap<List<CountryCode>, GetAllLibResponse>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src));
    }
}