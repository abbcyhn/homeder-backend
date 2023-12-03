using Application.Commons;
using Application.Commons.Mediator;
using Application.Commons.Resources;
using Application.Regions.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Application.Regions.Features.GetDistrictByName;

public class GetDistrictByNameHandler : BaseHandler<GetDistrictByNameRequest, IdValueResponse>
{
    public GetDistrictByNameHandler(IMapper mapper, AppDbContext ctx, IStringLocalizer<LocalizationMessage> localizer) : base(mapper, ctx, localizer)
    {
    }

    public override async Task<IdValueResponse> Execute(GetDistrictByNameRequest request, CancellationToken cancellationToken)
    {
        var district = await _ctx.GetEntity<District>()
            .FirstOrDefaultAsync(x => x.IdCity == request.CityId && EF.Functions.ILike(x.Value, request.DistrictName),
                cancellationToken: cancellationToken);

        return _mapper.Map<IdValueResponse>(district);
    }
}