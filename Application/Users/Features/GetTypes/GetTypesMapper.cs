using AutoMapper;

namespace Application.Users.Features.GetTypes;

public class GetTypesMapper : Profile
{
    public GetTypesMapper()
    {
        CreateMap<GetTypesInput, GetTypesRequest>();
    }
}