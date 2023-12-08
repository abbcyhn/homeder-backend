using Application.Commons.Services.MapService;
using AutoMapper;

namespace Application.Regions.Features.GetLocationsBySearchText;

public class GetLocationsBySearchTextMapper : Profile
{
    public GetLocationsBySearchTextMapper()
    {
        CreateMap<GetLocationsBySearchTextInput, GetLocationsBySearchTextRequest>();

        CreateMap<LocationData, GetLocationsBySearchTextIdValueDto>();

        CreateMap<List<LocationData>, GetLocationsBySearchTextResponse>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src));
    }
}
