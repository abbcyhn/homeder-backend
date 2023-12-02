using AutoMapper;

namespace Application.Regions.Features.GetDistrictByName;

public class GetDistrictByNameMapper : Profile
{
    public GetDistrictByNameMapper()
    {
        CreateMap<GetDistrictByNameInput, GetDistrictByNameRequest>();
    }
}