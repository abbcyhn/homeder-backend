using Application.Commons.DataAccess;
using Application.Commons.Resources;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Application.Commons.Mediator;

public abstract class BaseHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> 
    where TRequest : BaseRequest<TResponse>, IRequest<TResponse>
    where TResponse : BaseResponse
{
    protected readonly IMapper _mapper;
    protected readonly IUnitOfWork _uow;
    protected readonly AppDbContext _ctx;
    protected readonly IStringLocalizer<LocalizationMessage> _localizer;

    public BaseHandler(IMapper mapper, AppDbContext ctx, IStringLocalizer<LocalizationMessage> localizer)
    {
        _mapper = mapper;
        _ctx = ctx;
        _localizer = localizer;
    }

    public BaseHandler(IMapper mapper, IUnitOfWork uow, IStringLocalizer<LocalizationMessage> localizer)
    {
        _mapper = mapper;
        _uow = uow;
        _localizer = localizer;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        if (request.IsUserIdProvided && request.UserId != 0 && request.UserId != request.LoggedUserId) 
            throw new UnauthorizedAccessException(_localizer[LocalizationMessage.USER_ID_INVALID].Value);

        return await Execute(request, cancellationToken);
    }

    public abstract Task<TResponse> Execute(TRequest request, CancellationToken cancellationToken);
}