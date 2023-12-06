using AutoMapper;

namespace Application.Regions.Features.GetCountryByName;

public class GetCountryByNameMapper : Profile
{
    public GetCountryByNameMapper() 
    {
        CreateMap<GetCountryByNameInput, GetCountryByNameRequest>();
    }
}