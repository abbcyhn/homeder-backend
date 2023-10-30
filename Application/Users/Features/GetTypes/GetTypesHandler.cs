using Application.Commons;
using Application.Commons.Mediator;
using Application.Commons.Resources;
using Application.Users.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Application.Users.Features.GetTypes;

public class GetTypesHandler : BaseHandler<GetTypesRequest, IdValueListResponse>
{
    public GetTypesHandler(IMapper mapper, AppDbContext ctx, IStringLocalizer<LocalizationMessage> localizer) : base(mapper, ctx, localizer)
    {
    }

    public override async Task<IdValueListResponse> Execute(GetTypesRequest request, CancellationToken cancellationToken)
    {
        var types = await _ctx.GetEntity<UserType>()
            .ToListAsync(cancellationToken);

        return _mapper.Map<IdValueListResponse>(types);
    }
}