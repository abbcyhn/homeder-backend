using Application.Commons;
using Application.Commons.Mediator;
using Application.Commons.Resources;
using Application.Regions.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Application.Regions.Features.GetStateByName;

public class GetStateByNameHandler : BaseHandler<GetStateByNameRequest, IdValueResponse>
{
    public GetStateByNameHandler(IMapper mapper, AppDbContext ctx, IStringLocalizer<LocalizationMessage> localizer) : base(mapper, ctx, localizer)
    {
    }

    public override async Task<IdValueResponse> Execute(GetStateByNameRequest request, CancellationToken cancellationToken)
    {
        var state = await _ctx.GetEntity<State>()
            .FirstOrDefaultAsync(x => x.IdCountry == request.CountryId && EF.Functions.ILike(x.Value, request.StateName),
                cancellationToken: cancellationToken);

        return _mapper.Map<IdValueResponse>(state);
    }
}