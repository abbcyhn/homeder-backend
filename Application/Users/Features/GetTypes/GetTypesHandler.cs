using Application.Commons;
using Application.Commons.Mediator;
using Application.Users.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Features.GetTypes;

public class GetTypesHandler : BaseHandler<GetTypesRequest, IdValueListResponse>
{
    public GetTypesHandler(IMapper mapper, AppDbContext ctx) : base(mapper, ctx)
    {
    }

    public override async Task<IdValueListResponse> Execute(GetTypesRequest request, CancellationToken cancellationToken)
    {
        var types = await _ctx.GetEntity<UserType>()
            .ToListAsync(cancellationToken);

        return _mapper.Map<IdValueListResponse>(types);
    }
}