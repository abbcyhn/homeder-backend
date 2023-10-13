using Application.Commons.Dtos;
using Application.Regions.Entities;
using AutoMapper;

namespace Application.Regions.Features.GetAllCountries;

public class GetAllCountriesMapper : Profile
{
    public GetAllCountriesMapper()
    {
        CreateMap<Country, GetLibDto>();
        CreateMap<List<Country>, GetAllLibResponse>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src));
    }
}
