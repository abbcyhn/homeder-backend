using Application.Commons;
using Application.Commons.Mediator;
using Application.Commons.Resources;
using AutoMapper;
using Microsoft.Extensions.Localization;

namespace Application.Users.Features.GetUserPhoto;

public class GetUserPhotoHandler : BaseHandler<GetUserPhotoRequest, GetUserPhotoResponse>
{
    public GetUserPhotoHandler(IMapper mapper, AppDbContext ctx, IStringLocalizer<LocalizationMessage> localizer) : base(mapper, ctx, localizer)
    {
    }

    public override async Task<GetUserPhotoResponse> Execute(GetUserPhotoRequest request, CancellationToken cancellationToken)
    {
        string userPhotoPath = $"Photos/user-{request.UserId}.png";
        byte[] userPhoto = await File.ReadAllBytesAsync(userPhotoPath, cancellationToken);

        return new GetUserPhotoResponse { UserPhoto = userPhoto };
    }
}
