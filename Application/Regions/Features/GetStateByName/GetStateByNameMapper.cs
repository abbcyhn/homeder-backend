using AutoMapper;

namespace Application.Regions.Features.GetStateByName;

public class GetStateByNameMapper : Profile
{
    public GetStateByNameMapper() 
    {
        CreateMap<GetStateByNameInput, GetStateByNameRequest>();
    }
}