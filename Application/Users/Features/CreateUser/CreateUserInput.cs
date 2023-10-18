using Application.Commons.Mediator;

namespace Application.Users.Features.CreateUser;

public record CreateUserInput : BaseInput
{
    public string GoogleToken { get; set; }
    public int UserRole { get; set; }
}
