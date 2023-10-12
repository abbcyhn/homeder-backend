using Microsoft.AspNetCore.Mvc;

namespace Application.Users.Features.CreateUser;

public class CreateUserInput
{
    [FromQuery(Name = "googleToken")]
    public string GoogleToken { get; set; }
}
