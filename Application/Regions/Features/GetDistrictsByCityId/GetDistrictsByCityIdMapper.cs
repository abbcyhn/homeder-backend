using AutoMapper;

namespace Application.Regions.Features.GetDistrictsByCity;

public class GetDistrictsByCityIdMapper : Profile
{
    public GetDistrictsByCityIdMapper()
    {
        CreateMap<GetDistrictsByCityIdInput, GetDistrictsByCityIdRequest>();
    }
}