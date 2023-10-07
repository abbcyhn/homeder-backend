using Application.Regions.Configs;
using AutoMapper;

namespace Application.Regions.Features.GetAllCountries;

public class GetAllCountriesMapper : Profile
{
    public GetAllCountriesMapper()
    {
        CreateMap<Country, GetAllCountriesDto>();
        CreateMap<List<Country>, GetAllCountriesResponse>()
            .ForMember(dest => dest.Countries, opt => opt.MapFrom(src => src));
    }
}
