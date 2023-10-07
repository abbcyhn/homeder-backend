namespace WebAPI.Auth;

public class GoogleTokenData
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PhotoUrl { get; set; }
    public string Email { get; set; }
    public bool IsEmailVerified { get; set; }
}
