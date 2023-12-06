using AutoMapper;

namespace Application.Regions.Features.GetCityByName;

public class GetCityByNameMapper : Profile
{
    public GetCityByNameMapper()
    {
        CreateMap<GetCityByNameInput, GetCityByNameRequest>();
    }
}