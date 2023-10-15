using Application.Commons;
using Application.Commons.Mediator;
using Application.Regions.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Regions.Features.GetCountryById;

public class GetCountryByIdHandler : BaseHandler<GetCountryByIdRequest, IdValueResponse>
{
    public GetCountryByIdHandler(IMapper mapper, AppDbContext ctx) : base(mapper, ctx)
    {
    }

    public override async Task<IdValueResponse> Execute(GetCountryByIdRequest request, CancellationToken cancellationToken)
    {
        var country = await _ctx.GetEntity<Country>()
            .FirstOrDefaultAsync(x => x.Id == request.CountryId, cancellationToken: cancellationToken);
        
        if (country == null) 
        {
            return null;
        }

        return _mapper.Map<IdValueResponse>(country);
    }
}
