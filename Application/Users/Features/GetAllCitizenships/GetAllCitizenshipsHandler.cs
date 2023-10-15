using Application.Commons;
using Application.Commons.Dtos;
using Application.Regions.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Features.GetAllCitizenships;

public class GetAllCitizenshipsHandler : BaseRequestHandler<GetAllCitizenshipsRequest, GetAllLibResponse>
{
    public GetAllCitizenshipsHandler(IMapper mapper, AppDbContext ctx) : base(mapper, ctx)
    {
    }

    public override async Task<GetAllLibResponse> Handle(GetAllCitizenshipsRequest request, CancellationToken cancellationToken)
    {
        var citizenships = await _ctx.GetEntity<Citizenship>()
            .ToListAsync(cancellationToken);

        return _mapper.Map<GetAllLibResponse>(citizenships);
    }
}