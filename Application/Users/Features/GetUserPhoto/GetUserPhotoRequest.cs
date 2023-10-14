using MediatR;

namespace Application.Users.Features.GetUserPhoto;

public record GetUserPhotoRequest : IRequest<GetUserPhotoResponse>
{
    public int UserId { get; set; }
    public int LoggedUserId { get; set; }
}
