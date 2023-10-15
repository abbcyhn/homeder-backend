using Application.Commons;
using Application.Commons.Dtos;
using Application.Users.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Features.GetAllTypes;

public class GetAllTypesHandler : BaseRequestHandler<GetAllTypesRequest, GetAllLibResponse>
{
    public GetAllTypesHandler(IMapper mapper, AppDbContext ctx) : base(mapper, ctx)
    {
    }

    public override async Task<GetAllLibResponse> Handle(GetAllTypesRequest request, CancellationToken cancellationToken)
    {
        var types = await _ctx.GetEntity<UserType>()
            .ToListAsync(cancellationToken);

        return _mapper.Map<GetAllLibResponse>(types);
    }
}