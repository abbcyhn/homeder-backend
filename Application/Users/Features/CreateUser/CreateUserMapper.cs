using Application.Users.Entities;
using Application.Users.Features.CreateUser.Services.TokenService;
using AutoMapper;

namespace Application.Users.Features.CreateUser;

public class CreateUserMapper : Profile
{
    public CreateUserMapper()
    {
        CreateMap<CreateUserInput, CreateUserRequest>();

        CreateMap<GoogleTokenData, User>()
            .ForMember(dest => dest.PhotoUrl, opt => opt.Ignore());

        CreateMap<(User, string), HomederTokenData>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Item1.Id))
            .ForMember(dest => dest.UserRole, opt => opt.MapFrom(src => src.Item1.IdRole))
            .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.Item2));

        CreateMap<string, CreateUserResponse>()
            .ForMember(dest => dest.HomederToken, opt => opt.MapFrom(src => src));

        CreateMap<GoogleTokenData, User>()
            .ForMember(dest => dest.UserEmails, opt => 
                opt.MapFrom(src => src.Email == null ? null : new List<UserEmail> { new() { Email = src.Email, IsVerified = src.IsEmailVerified } }));
    }
}
