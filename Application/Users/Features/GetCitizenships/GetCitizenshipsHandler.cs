using Application.Commons;
using Application.Commons.Mediator;
using Application.Regions.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Features.GetCitizenships;

public class GetCitizenshipsHandler : BaseHandler<GetCitizenshipsRequest, IdValueListResponse>
{
    public GetCitizenshipsHandler(IMapper mapper, AppDbContext ctx) : base(mapper, ctx)
    {
    }

    public override async Task<IdValueListResponse> Execute(GetCitizenshipsRequest request, CancellationToken cancellationToken)
    {
        var citizenships = await _ctx.GetEntity<Citizenship>()
            .ToListAsync(cancellationToken);

        return _mapper.Map<IdValueListResponse>(citizenships);
    }
}