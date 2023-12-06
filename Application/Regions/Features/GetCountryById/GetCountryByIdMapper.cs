using AutoMapper;

namespace Application.Regions.Features.GetCountryById;

public class GetCountryByIdMapper : Profile
{
    public GetCountryByIdMapper() 
    {
        CreateMap<GetCountryByIdInput, GetCountryByIdRequest>();
    }
}
