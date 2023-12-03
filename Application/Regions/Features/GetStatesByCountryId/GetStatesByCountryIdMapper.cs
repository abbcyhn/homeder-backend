using AutoMapper;

namespace Application.Regions.Features.GetStatesByCountryId;

public class GetStatesByCountryIdMapper : Profile
{
    public GetStatesByCountryIdMapper()
    {
        CreateMap<GetStatesByCountryIdInput, GetStatesByCountryIdRequest>();
    }
}