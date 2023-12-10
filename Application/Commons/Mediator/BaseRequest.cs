using MediatR;

namespace Application.Commons.Mediator;

public record BaseRequest<TResponse> : IRequest<TResponse> where TResponse : BaseResponse
{
    public int? UserId { get; set; }
    public int LoggedUserId { get; set; }
    public string HostUrl { get; set; }
    public string AcceptLanguage { get; set; }
}
