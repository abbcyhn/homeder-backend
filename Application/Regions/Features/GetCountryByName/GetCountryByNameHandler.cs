using Application.Commons;
using Application.Commons.Mediator;
using Application.Commons.Resources;
using Application.Regions.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Application.Regions.Features.GetCountryByName;

public class GetCountryByNameHandler : BaseHandler<GetCountryByNameRequest, IdValueResponse>
{
    public GetCountryByNameHandler(IMapper mapper, AppDbContext ctx, IStringLocalizer<LocalizationMessage> localizer) :
        base(mapper, ctx, localizer)
    {
    }

    public override async Task<IdValueResponse> Execute(GetCountryByNameRequest request,
        CancellationToken cancellationToken)
    {
        var country = await _ctx.GetEntity<Country>()
            .FirstOrDefaultAsync(x => EF.Functions.ILike(x.Value, request.CountryName),
                cancellationToken: cancellationToken);

        return _mapper.Map<IdValueResponse>(country);
    }
}