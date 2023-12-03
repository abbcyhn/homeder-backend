using Application.Commons;
using Application.Commons.Mediator;
using Application.Commons.Resources;
using Application.Regions.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Application.Regions.Features.GetCitiesByStateId;

public class GetCitiesByStateIdHandler : BaseHandler<GetCitiesByStateIdRequest, IdValueListResponse>
{
    public GetCitiesByStateIdHandler(IMapper mapper, AppDbContext ctx, IStringLocalizer<LocalizationMessage> localizer) : base(mapper, ctx, localizer)
    {
    }

    public override async Task<IdValueListResponse> Execute(GetCitiesByStateIdRequest request, CancellationToken cancellationToken)
    {
        var states = await _ctx.GetEntity<City>().Where(x => x.IdState == request.StateId).ToListAsync(cancellationToken);

        return _mapper.Map<IdValueListResponse>(states);
    }
}