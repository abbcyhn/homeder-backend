using Application.Commons;
using Application.Commons.Helpers;
using Application.Commons.Mediator;
using AutoMapper;
using Microsoft.Extensions.Localization;

namespace Application.Users.Features.UpdateUserPhoto;

public class UpdateUserPhotoHandler : BaseHandler<UpdateUserPhotoRequest, UpdateUserPhotoResponse>
{
    public UpdateUserPhotoHandler(IMapper mapper, AppDbContext ctx, IStringLocalizer<LocalizationMessage> localizer) : base(mapper, ctx, localizer)
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
