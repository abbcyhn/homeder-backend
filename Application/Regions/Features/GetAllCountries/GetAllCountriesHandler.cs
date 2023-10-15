using Application.Commons;
using Application.Commons.Dtos;
using Application.Regions.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Regions.Features.GetAllCountries;

public class GetAllCountriesHandler : BaseRequestHandler<GetAllCountriesRequest, GetAllLibResponse>
{
    public GetAllCountriesHandler(IMapper mapper, AppDbContext ctx) : base(mapper, ctx)
    {
    }

    public override async Task<GetAllLibResponse> Handle(GetAllCountriesRequest request, CancellationToken cancellationToken)
    {
        var countries = await _ctx.GetEntity<Country>()
            .ToListAsync(cancellationToken);

        return _mapper.Map<GetAllLibResponse>(countries);
    }
}
