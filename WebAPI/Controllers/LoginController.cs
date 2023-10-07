using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Auth;

namespace WebAPI.Controllers;

[Route("api/login")]
public class LoginController : ControllerBase
{
    private readonly JwtDecoder _jwtDecoder;
    private readonly JwtGenerator _jwtGenerator;

    public LoginController(JwtDecoder jwtDecoder, JwtGenerator jwtGenerator)
    {
        _jwtDecoder = jwtDecoder;
        _jwtGenerator = jwtGenerator;
    }


    [HttpPost]
    public IActionResult LoginViaGoogle([FromBody] string googleToken)
    {
        // TODO: validate google token
        var googleTokenData = _jwtDecoder.DecodeGoogleToken(googleToken);
        // TODO: user should be created here
        string jwtToken = _jwtGenerator.Generate(0, googleTokenData.Name);
        return Ok(jwtToken);
    }
}
