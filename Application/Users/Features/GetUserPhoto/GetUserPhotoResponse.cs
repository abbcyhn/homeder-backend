using Application.Commons.Mediator;

namespace Application.Users.Features.GetUserPhoto;

public record GetUserPhotoResponse : BaseResponse
{
    public byte[] UserPhoto { get; set; }
}
