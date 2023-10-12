using Application.Users.Entities;
using AutoMapper;

namespace Application.Users.Features.UpdateUser;

public class UpdateUserMapper : Profile
{
    public UpdateUserMapper()
    {
        CreateMap<UpdateUserInput, UpdateUserRequest>()
            .ForMember(d => d.IdUserType, o => o.MapFrom(s => s.UserType))
            .ForMember(d => d.IdCitizenship, o => o.MapFrom(s => s.Citizenship))
            .ForMember(d => d.IdRole, o => o.MapFrom(s => s.UserRole));

        CreateMap<UpdateUserRequest, User>();

        CreateMap<UpdateUserRequest, UserDetails>()
            .ForMember(d=>d.NoOfPeople, o=>o.MapFrom(s=>s.NumberOfPeople))
            .ForMember(d => d.IdUser, o => o.MapFrom(s => s.Id));

        CreateMap<UpdateUserRequest, UserPhone>();
    }
}