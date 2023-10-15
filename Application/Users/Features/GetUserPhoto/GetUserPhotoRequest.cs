using Application.Commons.Mediator;
using MediatR;

namespace Application.Users.Features.GetUserPhoto;

public record GetUserPhotoRequest : BaseRequest<GetUserPhotoResponse>
{
}
