using Application.Commons;
using Application.Commons.Services.TokenService;
using Application.Commons.Utilities;
using Application.Users.Entities;
using Application.Users.Features.UpdateUserPhoto;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Features.CreateUser;

public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    private readonly IMapper _mapper;
    private readonly AppDbContext _ctx;
    private readonly IMediator _mediator;
    private readonly ITokenService _tokenService;
    private readonly IConverterUtility _converterUtility;

    public CreateUserHandler(AppDbContext ctx, IMapper mapper, ITokenService tokenService, IConverterUtility converterUtility, IMediator mediator)
    {
        _ctx = ctx;
        _mapper = mapper;
        _mediator = mediator;
        _tokenService = tokenService;
        _converterUtility = converterUtility;
    }

    public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var googleTokenData = _tokenService.DecodeGoogleToken(request.GoogleToken);

        var user = _ctx.GetEntity<User>()
            .Include(u => u.UserEmails)
            .FirstOrDefault(u => u.UserEmails.Any(e => e.Email == googleTokenData.Email));

        if (user == null)
        {
            user = _mapper.Map<User>(googleTokenData);
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

        var userPhoto = await _converterUtility.ConvertPhotoUrlToBytes(photoUrl, cancellationToken);
        var request = new UpdateUserPhotoRequest { UserId = userId, UserPhoto = userPhoto, LoggedUserId = userId, HostUrl = hostUrl };
        var response = await _mediator.Send(request, cancellationToken);

        return response.PhotoUrl;
    }
}