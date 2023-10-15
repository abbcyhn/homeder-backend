using Application.Commons.Mediator;
using Application.Regions.Entities;
using AutoMapper;

namespace Application.Regions.Features.GetCountryById;

public class GetCountryByIdMapper : Profile
{
    public GetCountryByIdMapper() 
    {
        CreateMap<GetCountryByIdInput, GetCountryByIdRequest>();

        CreateMap<Country, IdValueResponse>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src));
    }
}
