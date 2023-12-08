using Application.Commons;
using Application.Commons.Mediator;
using Application.Commons.Resources;
using Application.Commons.Services.MapService;
using AutoMapper;
using Microsoft.Extensions.Localization;

namespace Application.Regions.Features.GetLocationsBySearchText;

public class GetLocationsBySearchTextHandler : BaseHandler<GetLocationsBySearchTextRequest, GetLocationsBySearchTextResponse>
{
    private readonly IMapService _mapService;

    public GetLocationsBySearchTextHandler(IMapper mapper, 
        AppDbContext ctx,
        IMapService mapService,
        IStringLocalizer<LocalizationMessage> localizer)
        : base(mapper, ctx, localizer) 
        {
            _mapService = mapService;
        }

    public override async Task<GetLocationsBySearchTextResponse> Execute(GetLocationsBySearchTextRequest request, 
        CancellationToken cancellationToken)
    {
        var locations = await _mapService.GetLocations(request.SearchText, request.AcceptLanguage, cancellationToken);
        
        return _mapper.Map<GetLocationsBySearchTextResponse>(locations);
    }
}
