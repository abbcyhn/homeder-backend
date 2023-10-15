using Application.Commons;
using Application.Commons.Mediator;
using Application.Regions.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Regions.Features.GetCountries;

public class GetAllCountriesHandler : BaseHandler<GetCountriesRequest, IdValueListResponse>
{
    public GetAllCountriesHandler(IMapper mapper, AppDbContext ctx) : base(mapper, ctx)
    {
    }

    public override async Task<IdValueListResponse> Execute(GetCountriesRequest request, CancellationToken cancellationToken)
    {
        var countries = await _ctx.GetEntity<Country>()
            .ToListAsync(cancellationToken);

        return _mapper.Map<IdValueListResponse>(countries);
    }
}
