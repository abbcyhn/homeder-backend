using Application.Commons;
using Application.Regions.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Regions.Features.GetAllCountries;

public class GetAllCountriesHandler : IRequestHandler<GetAllCountriesRequest, GetAllCountriesResponse>
{
    private IMapper _mapper;
    private readonly AppDbContext _ctx;

    public GetAllCountriesHandler(AppDbContext ctx, IMapper mapper)
    {
        _ctx = ctx;
        _mapper = mapper;

    }

    public async Task<GetAllCountriesResponse> Handle(GetAllCountriesRequest request, CancellationToken cancellationToken)
    {
        var countries = await _ctx.GetEntity<Country>()
            .ToListAsync(cancellationToken);

        return _mapper.Map<GetAllCountriesResponse>(countries);
    }
}
