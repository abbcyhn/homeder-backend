using Application.Commons.DataAccess;
using AutoMapper;
using MediatR;

namespace Application.Commons.Mediator;

public abstract class BaseHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> 
    where TRequest : BaseRequest<TResponse>, IRequest<TResponse>
    where TResponse : BaseResponse
{
    protected readonly IMapper _mapper;
    protected readonly AppDbContext _ctx;
    protected readonly IUnitOfWork _uow;

    public BaseHandler(IMapper mapper, AppDbContext ctx)
    {
        _mapper = mapper;
        _ctx = ctx;
    }

    public BaseHandler(IMapper mapper, IUnitOfWork uow)
    {
        _mapper = mapper;
        _uow = uow;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        if (request.IsUserIdProvided && request.UserId != 0 && request.UserId != request.LoggedUserId) 
            throw new UnauthorizedAccessException("Given user id is not valid");

        return await Execute(request, cancellationToken);
    }

    public abstract Task<TResponse> Execute(TRequest request, CancellationToken cancellationToken);
}