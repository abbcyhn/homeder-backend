using Application.Commons.Mediator;
using Application.Users.Entities;
using AutoMapper;

namespace Application.Users.Features.GetTypes;

public class GetTypesMapper : Profile
{
    public GetTypesMapper()
    {
        CreateMap<GetTypesInput, GetTypesRequest>();

        CreateMap<UserType, IdValueDto>();

        CreateMap<List<UserType>, IdValueListResponse>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src));
    }
}