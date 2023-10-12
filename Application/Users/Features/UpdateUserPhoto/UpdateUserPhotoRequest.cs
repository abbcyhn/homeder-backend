using MediatR;

namespace Application.Users.Features.UpdateUserPhoto;

public class UpdateUserPhotoRequest : IRequest<UpdateUserPhotoResponse>
{
    public int UserId { get; set; }
    public byte[] UserPhoto { get; set; }
    public string HostUrl { get; set; }
    public int LoggedUserId { get; set; }
}
