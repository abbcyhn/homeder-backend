using Application.Commons;
using Application.Commons.Dtos;
using Application.Regions.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Regions.Features.GetAllCountries;

public class GetAllCountriesHandler : IRequestHandler<GetAllCountriesRequest, GetAllLibResponse>
{
    private IMapper _mapper;
    private readonly AppDbContext _ctx;

    public GetAllCountriesHandler(AppDbContext ctx, IMapper mapper)
    {
        _ctx = ctx;
        _mapper = mapper;

    }

    public async Task<GetAllLibResponse> Handle(GetAllCountriesRequest request, CancellationToken cancellationToken)
    {
        var countries = await _ctx.GetEntity<Country>()
            .ToListAsync(cancellationToken);

        return _mapper.Map<GetAllLibResponse>(countries);
    }
}
