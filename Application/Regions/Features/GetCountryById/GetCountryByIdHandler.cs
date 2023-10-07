using Application.Commons;
using Application.Regions.Configs;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Regions.Features.GetCountryById;

public class GetCountryByIdHandler : IRequestHandler<GetCountryByIdRequest, GetCountryByIdResponse>
{
    private IMapper _mapper;
    private readonly AppDbContext _ctx;

    public GetCountryByIdHandler(AppDbContext ctx, IMapper mapper)
    {
        _ctx = ctx;
        _mapper = mapper;
    }

    public async Task<GetCountryByIdResponse> Handle(GetCountryByIdRequest request, CancellationToken cancellationToken)
    {
        var country = await _ctx.GetEntity<Country>()
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        
        if (country == null) 
        {
            return null;
        }

        return _mapper.Map<GetCountryByIdResponse>(country);
    }
}
