using Application.Commons;
using Application.Commons.Mediator;
using Application.Commons.Resources;
using Application.Regions.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Application.Regions.Features.GetDistrictsByCityId;

public class GetDistrictsByCityIdHandler : BaseHandler<GetDistrictsByCityIdRequest, IdValueListResponse>
{
    public GetDistrictsByCityIdHandler(IMapper mapper, AppDbContext ctx, IStringLocalizer<LocalizationMessage> localizer)
        : base(mapper, ctx, localizer)
    {
    }

    public override async Task<IdValueListResponse> Execute(GetDistrictsByCityIdRequest idRequest,
        CancellationToken cancellationToken)
    {
        var districts = await _ctx.GetEntity<District>().Where(x => x.IdCity == idRequest.CityId)
            .ToListAsync(cancellationToken: cancellationToken);

        return _mapper.Map<IdValueListResponse>(districts);
    }
}