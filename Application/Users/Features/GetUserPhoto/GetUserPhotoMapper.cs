using AutoMapper;

namespace Application.Users.Features.GetUserPhoto;

public class GetUserPhotoMapper : Profile
{
    public GetUserPhotoMapper()
    {
        CreateMap<GetUserPhotoInput, GetUserPhotoRequest>();
    }
}
