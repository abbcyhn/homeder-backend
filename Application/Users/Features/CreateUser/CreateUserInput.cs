using Application.Commons.Mediator;
using Application.Users.Enums;

namespace Application.Users.Features.CreateUser;

public record CreateUserInput : BaseInput
{
    public string GoogleToken { get; set; }
    public UserRoleEnum UserRole { get; set; }
}
