using Application.Commons.Mediator;
using MediatR;

namespace Application.Users.Features.UpdateUserPhoto;

public record UpdateUserPhotoRequest : BaseRequest<UpdateUserPhotoResponse>
{
    public byte[] UserPhoto { get; set; }
}
