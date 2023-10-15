using Application.Commons.Dtos;
using Application.Users.Entities;
using AutoMapper;

namespace Application.Users.Features.GetAllTypes;

public class GetAllTypesMapper : Profile
{
    public GetAllTypesMapper()
    {
        CreateMap<UserType, GetLibDto>();
        
        CreateMap<List<UserType>, GetAllLibResponse>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src));
    }
}