using Application.Commons.Mediator;

namespace Application.Users.Features.UpdateUserPhoto;

public record UpdateUserPhotoResponse : BaseResponse
{
    public string PhotoUrl { get; set; }
}