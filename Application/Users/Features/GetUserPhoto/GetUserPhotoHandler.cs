using Application.Commons;
using Application.Commons.Mediator;
using AutoMapper;
using MediatR;

namespace Application.Users.Features.GetUserPhoto;

public class GetUserPhotoHandler : BaseHandler<GetUserPhotoRequest, GetUserPhotoResponse>
{
    public GetUserPhotoHandler(IMapper mapper, AppDbContext ctx) : base(mapper, ctx)
    {
    }

    public override async Task<GetUserPhotoResponse> Execute(GetUserPhotoRequest request, CancellationToken cancellationToken)
    {
        string userPhotoPath = $"Photos/user-{request.UserId}.png";
        byte[] userPhoto = await File.ReadAllBytesAsync(userPhotoPath, cancellationToken);

        return new GetUserPhotoResponse { UserPhoto = userPhoto };
    }
}
