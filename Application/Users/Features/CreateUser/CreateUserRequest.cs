using Application.Commons.Mediator;

namespace Application.Users.Features.CreateUser;

public record CreateUserRequest : BaseRequest<CreateUserResponse>
{
    public string GoogleToken { get; set; }
    public int IdRole { get; set; }
}
