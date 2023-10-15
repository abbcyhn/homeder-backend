using MediatR;

namespace Application.Commons.Mediator;

public record BaseRequest<TResponse> : IRequest<TResponse> where TResponse : BaseResponse
{
    public int UserId { get; set; }
    public bool IsUserIdProvided { get; set; }
    public int LoggedUserId { get; set; }
    public string HostUrl { get; set; }
}
