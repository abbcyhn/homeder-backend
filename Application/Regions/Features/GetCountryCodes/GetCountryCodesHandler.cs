using Application.Commons;
using Application.Commons.Mediator;
using Application.Commons.Resources;
using Application.Regions.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Application.Regions.Features.GetCountryCodes;

public class GetAllCountryCodesHandler : BaseHandler<GetAllCountryCodesRequest, IdValueListResponse>
{
    public GetAllCountryCodesHandler(IMapper mapper, AppDbContext ctx, IStringLocalizer<LocalizationMessage> localizer) : base(mapper, ctx, localizer)
    {
    }

    public override async Task<IdValueListResponse> Execute(GetAllCountryCodesRequest request, CancellationToken cancellationToken)
    {
        var countryCodes = await _ctx.GetEntity<CountryCode>()
            .ToListAsync(cancellationToken);

        return _mapper.Map<IdValueListResponse>(countryCodes);
    }
}