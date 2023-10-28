using Application.Commons;
using Application.Commons.Helpers;
using Application.Commons.Mediator;
using Application.Regions.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Application.Regions.Features.GetCountryById;

public class GetCountryByIdHandler : BaseHandler<GetCountryByIdRequest, IdValueResponse>
{
    public GetCountryByIdHandler(IMapper mapper, AppDbContext ctx, IStringLocalizer<LocalizationMessage> localizer) : base(mapper, ctx, localizer)
    {
    }

    public override async Task<IdValueResponse> Execute(GetCountryByIdRequest request, CancellationToken cancellationToken)
    {
        var country = await _ctx.GetEntity<Country>()
            .FirstOrDefaultAsync(x => x.Id == request.CountryId, cancellationToken: cancellationToken);
        return _mapper.Map<IdValueResponse>(country);
    }
}
