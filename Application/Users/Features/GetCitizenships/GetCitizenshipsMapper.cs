using AutoMapper;

namespace Application.Users.Features.GetCitizenships;

public class GetCitizenshipsMapper : Profile
{
    public GetCitizenshipsMapper()
    {
        CreateMap<GetCitizenshipsInput, GetCitizenshipsRequest>();
    }
}