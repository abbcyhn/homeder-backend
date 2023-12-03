using AutoMapper;

namespace Application.Regions.Features.GetDistrictsByCityId;

public class GetDistrictsByCityIdMapper : Profile
{
    public GetDistrictsByCityIdMapper()
    {
        CreateMap<GetDistrictsByCityIdInput, GetDistrictsByCityIdRequest>();
    }
}