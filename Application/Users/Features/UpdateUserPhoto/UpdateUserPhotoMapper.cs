using AutoMapper;

namespace Application.Users.Features.UpdateUserPhoto;

public class UpdateUserPhotoMapper : Profile
{
    public UpdateUserPhotoMapper()
    {
        CreateMap<UpdateUserPhotoInput, UpdateUserPhotoRequest>();
    }
}
