using Application.Commons;
using Application.Commons.Helpers;
using Application.Commons.Mediator;
using Application.Regions.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Application.Users.Features.GetCitizenships;

public class GetCitizenshipsHandler : BaseHandler<GetCitizenshipsRequest, IdValueListResponse>
{
    public GetCitizenshipsHandler(IMapper mapper, AppDbContext ctx, IStringLocalizer<LocalizationMessage> localizer) : base(mapper, ctx, localizer)
    {
    }

    public override async Task<IdValueListResponse> Execute(GetCitizenshipsRequest request, CancellationToken cancellationToken)
    {
        var citizenships = await _ctx.GetEntity<Citizenship>()
            .ToListAsync(cancellationToken);

        return _mapper.Map<IdValueListResponse>(citizenships);
    }
}