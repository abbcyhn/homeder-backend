using Application.Commons;
using AutoMapper;
using MediatR;

namespace Application.Users.Features.GetUserPhoto;

public class GetUserPhotoHandler : BaseRequestHandler<GetUserPhotoRequest, GetUserPhotoResponse>
{
    public GetUserPhotoHandler(IMapper mapper, AppDbContext ctx) : base(mapper, ctx)
    {
    }

    public override async Task<GetUserPhotoResponse> Handle(GetUserPhotoRequest request, CancellationToken cancellationToken)
    {
        if (request.UserId != request.LoggedUserId) 
            throw new UnauthorizedAccessException("Given user id is not valid");
        
        string userPhotoPath = $"Photos/user-{request.UserId}.png";
        byte[] userPhoto = await File.ReadAllBytesAsync(userPhotoPath, cancellationToken);

        return new GetUserPhotoResponse { UserPhoto = userPhoto };
    }
}
