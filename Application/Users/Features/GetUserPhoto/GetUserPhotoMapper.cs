using Application.Users.Features.GetUserPhoto;
using AutoMapper;

namespace Application.Users.Features.CreateUser;

public class GetUserPhotoMapper : Profile
{
    public GetUserPhotoMapper()
    {
        CreateMap<GetUserPhotoInput, GetUserPhotoRequest>();
    }
}
