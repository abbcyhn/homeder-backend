using Application.Commons.Mediator;
using Application.Regions.Entities;
using AutoMapper;

namespace Application.Regions.Features.GetCountries;

public class GetCountriesMapper : Profile
{
    public GetCountriesMapper()
    {
        CreateMap<List<Country>, IdValueListResponse>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src));
    }
}
