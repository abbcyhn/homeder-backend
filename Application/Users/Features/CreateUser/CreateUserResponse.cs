using Application.Commons.Mediator;

namespace Application.Users.Features.CreateUser;

public record CreateUserResponse : BaseResponse
{
    public string HomederToken { get; set; }
}
