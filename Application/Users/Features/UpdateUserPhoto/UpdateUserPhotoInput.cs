using Application.Commons.Mediator;

namespace Application.Users.Features.UpdateUserPhoto;

public record UpdateUserPhotoInput : BaseInput
{
    public byte[] UserPhoto { get; set; }
}
