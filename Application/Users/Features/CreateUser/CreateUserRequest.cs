using MediatR;

namespace Application.Users.Features.CreateUser;

public class CreateUserRequest : IRequest<CreateUserResponse>
{
    public string GoogleToken { get; set; }
    public string HostUrl { get; set; }
}
