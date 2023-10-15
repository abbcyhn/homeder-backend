using Application.Commons;
using Application.Commons.Dtos;
using Application.Regions.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Regions.Features.GetAllCountryCodes;

public class GetAllCountryCodesHandler : BaseRequestHandler<GetAllCountryCodesRequest, GetAllLibResponse>
{
    public GetAllCountryCodesHandler(IMapper mapper, AppDbContext ctx) : base(mapper, ctx)
    {
    }

    public override async Task<GetAllLibResponse> Handle(GetAllCountryCodesRequest request, CancellationToken cancellationToken)
    {
        var countryCodes = await _ctx.GetEntity<CountryCode>()
            .ToListAsync(cancellationToken);

        return _mapper.Map<GetAllLibResponse>(countryCodes);
    }
}