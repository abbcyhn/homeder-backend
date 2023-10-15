using Application.Commons;
using Application.Commons.Mediator;
using Application.Regions.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Regions.Features.GetAllCountryCodes;

public class GetAllCountryCodesHandler : BaseHandler<GetAllCountryCodesRequest, IdValueListResponse>
{
    public GetAllCountryCodesHandler(IMapper mapper, AppDbContext ctx) : base(mapper, ctx)
    {
    }

    public override async Task<IdValueListResponse> Execute(GetAllCountryCodesRequest request, CancellationToken cancellationToken)
    {
        var countryCodes = await _ctx.GetEntity<CountryCode>()
            .ToListAsync(cancellationToken);

        return _mapper.Map<IdValueListResponse>(countryCodes);
    }
}