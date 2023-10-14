using Application.Commons;
using Application.Commons.Dtos;
using Application.Regions.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Regions.Features.GetCountryById;

public class GetCountryByIdHandler : IRequestHandler<GetCountryByIdRequest, GetLibResponse>
{
    private readonly IMapper _mapper;
    private readonly AppDbContext _ctx;

    public GetCountryByIdHandler(AppDbContext ctx, IMapper mapper)
    {
        _ctx = ctx;
        _mapper = mapper;
    }

    public async Task<GetLibResponse> Handle(GetCountryByIdRequest request, CancellationToken cancellationToken)
    {
        var country = await _ctx.GetEntity<Country>()
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        
        if (country == null) 
        {
            return null;
        }

        return _mapper.Map<GetLibResponse>(country);
    }
}
