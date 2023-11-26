using Application.Commons.Mediator;
using Application.Regions.Entities;
using AutoMapper;

namespace Application.Regions.Features.GetCountryByName;

public class GetCountryByNameMapper : Profile
{
    public GetCountryByNameMapper() 
    {
        CreateMap<GetCountryByNameInput, GetCountryByNameRequest>();
        
        
        CreateMap<Country, IdValueResponse>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src));
    }
}