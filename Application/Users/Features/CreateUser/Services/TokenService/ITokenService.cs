namespace Application.Users.Features.CreateUser.Services.TokenService;

public interface ITokenService
{
    string GenerateHomederToken(HomederTokenData homederTokenData);
    GoogleTokenData DecodeGoogleToken(string googleToken);
    bool ValidateGoogleTokenAsync(string googleToken);
}
