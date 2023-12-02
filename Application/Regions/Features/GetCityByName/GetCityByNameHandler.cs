using Application.Commons;
using Application.Commons.Mediator;
using Application.Commons.Resources;
using Application.Regions.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Application.Regions.Features.GetCityByName;

public class GetCityByNameHandler : BaseHandler<GetCityByNameRequest, IdValueResponse>
{
    public GetCityByNameHandler(IMapper mapper, AppDbContext ctx, IStringLocalizer<LocalizationMessage> localizer) : base(mapper, ctx, localizer)
    {
    }

    public override async Task<IdValueResponse> Execute(GetCityByNameRequest request, CancellationToken cancellationToken)
    {
        var city = await _ctx.GetEntity<City>()
            .FirstOrDefaultAsync(x => x.IdState == request.StateId && EF.Functions.ILike(x.Value, request.CityName),
                cancellationToken: cancellationToken);

        return _mapper.Map<IdValueResponse>(city);
    }
}