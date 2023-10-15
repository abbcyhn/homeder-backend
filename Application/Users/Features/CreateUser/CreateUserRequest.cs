using Application.Commons.Mediator;
using MediatR;

namespace Application.Users.Features.CreateUser;

public record CreateUserRequest : BaseRequest<CreateUserResponse>
{
    public string GoogleToken { get; set; }
}
