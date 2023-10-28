using Application.Commons;
using Application.Commons.Helpers;
using Application.Commons.Mediator;
using Application.Users.Entities;
using Application.Users.Features.CreateUser.Services.ImageService;
using Application.Users.Features.CreateUser.Services.TokenService;
using Application.Users.Features.UpdateUserPhoto;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Application.Users.Features.CreateUser;

public class CreateUserHandler : BaseHandler<CreateUserRequest, CreateUserResponse>
{
    private readonly IMediator _mediator;
    private readonly ITokenService _tokenService;
    private readonly IImageService _imageService;

    public CreateUserHandler(AppDbContext ctx, IMapper mapper, ITokenService tokenService, IImageService imageService, IMediator mediator, IStringLocalizer<LocalizationMessage> localizer) : base(mapper, ctx, localizer)
    {
        _mediator = mediator;
        _tokenService = tokenService;
        _imageService = imageService;
    }

    public override async Task<CreateUserResponse> Execute(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var googleTokenData = _tokenService.DecodeGoogleToken(request.GoogleToken);

        var user = await _ctx.GetEntity<User>()
            .Include(u => u.UserEmails)
            .FirstOrDefaultAsync(u => u.UserEmails.Any(e => e.Email == googleTokenData.Email), cancellationToken);

        if (user == null)
        {
            user = _mapper.Map<User>(googleTokenData);
            user.IdRole = request.IdRole;
            await _ctx.GetEntity<User>().AddAsync(user, cancellationToken);
            await _ctx.SaveChangesAsync(cancellationToken);

            user.PhotoUrl = await SavePhoto(user.Id, googleTokenData.PhotoUrl, request.HostUrl, cancellationToken);
            await _ctx.SaveChangesAsync(cancellationToken);
        }

        var homederTokenData = _mapper.Map<HomederTokenData>((user, googleTokenData.Email));
        string homederToken = _tokenService.GenerateHomederToken(homederTokenData);

        var response = new CreateUserResponse { HomederToken = homederToken };
        return response;
    }

    private async Task<string> SavePhoto(int userId, string photoUrl, string hostUrl, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(photoUrl)) 
            return null;

        var userPhoto = await _imageService.ConvertImageUrlToBytes(photoUrl, cancellationToken);
        var request = new UpdateUserPhotoRequest { UserId = userId, UserPhoto = userPhoto, LoggedUserId = userId, HostUrl = hostUrl };
        var response = await _mediator.Send(request, cancellationToken);

        return response.PhotoUrl;
    }
}