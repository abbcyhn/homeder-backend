using Application.Regions.Features.GetLocationsBySearchText.Services;
using AutoMapper;

namespace Application.Regions.Features.GetLocationsBySearchText;

public class GetLocationsBySearchTextMapper : Profile
{
    public GetLocationsBySearchTextMapper()
    {
        CreateMap<GetLocationsBySearchTextInput, GetLocationsBySearchTextRequest>();

        CreateMap<LocationIdValue, GetLocationsBySearchTextIdValueDto>();

        CreateMap<LocationIdValueList, GetLocationsBySearchTextResponse>();
    }
}
