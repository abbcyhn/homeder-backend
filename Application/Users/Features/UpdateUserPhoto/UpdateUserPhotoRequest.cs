using Application.Commons.Mediator;

namespace Application.Users.Features.UpdateUserPhoto;

public record UpdateUserPhotoRequest : BaseRequest<UpdateUserPhotoResponse>
{
    public byte[] UserPhoto { get; set; }
}
