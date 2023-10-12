namespace Application.Commons.Services.TokenService;

public class GoogleTokenData
{
    public string Aud { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PhotoUrl { get; set; }
    public string Email { get; set; }
    public bool IsEmailVerified { get; set; }
}
