using Application.Commons;
using Application.Commons.Mediator;
using Application.Commons.Resources;
using Application.Regions.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Application.Regions.Features.GetStatesByCountryId;

public class GetStatesByCountryIdHandler : BaseHandler<GetStatesByCountryIdRequest, IdValueListResponse>
{
    public GetStatesByCountryIdHandler(IMapper mapper, AppDbContext ctx, IStringLocalizer<LocalizationMessage> localizer) : base(mapper, ctx, localizer)
    {
    }

    public override async Task<IdValueListResponse> Execute(GetStatesByCountryIdRequest request, CancellationToken cancellationToken)
    {
        var states = await _ctx.GetEntity<State>().Where(x => x.IdCountry == request.CountryId).ToListAsync(cancellationToken);

        return _mapper.Map<IdValueListResponse>(states);
    }
}