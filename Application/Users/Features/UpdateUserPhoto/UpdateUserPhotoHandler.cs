using Application.Commons;
using Application.Commons.Mediator;
using AutoMapper;
using MediatR;

namespace Application.Users.Features.UpdateUserPhoto;

public class UpdateUserPhotoHandler : BaseHandler<UpdateUserPhotoRequest, UpdateUserPhotoResponse>
{
    public UpdateUserPhotoHandler(IMapper mapper, AppDbContext ctx) : base(mapper, ctx)
    {
    }

    public override async Task<UpdateUserPhotoResponse> Execute(UpdateUserPhotoRequest request, CancellationToken cancellationToken)
    {
        string photoPath = GetPhotoPath(request.UserId);

        await File.WriteAllBytesAsync(photoPath, request.UserPhoto, cancellationToken);

        return new UpdateUserPhotoResponse { PhotoUrl = $"{request.HostUrl}" };
    }

    private string GetPhotoPath(int userId)
    {
        string folderPath = "Photos";
        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        return $"{folderPath}/user-{userId}.png";
    }
}
