using Application.Commons;
using Application.Commons.Mediator;
using Application.Commons.Resources;
using Application.Regions.Features.GetLocationsBySearchText.Services;
using AutoMapper;
using Microsoft.Extensions.Localization;

namespace Application.Regions.Features.GetLocationsBySearchText;

public class GetLocationsBySearchTextHandler : BaseHandler<GetLocationsBySearchTextRequest, GetLocationsBySearchTextResponse>
{
    private readonly IGoogleMapAutocompleteService _googleMapAutocompleteService;

    public GetLocationsBySearchTextHandler(IMapper mapper, AppDbContext ctx,
        IStringLocalizer<LocalizationMessage> localizer,
        IGoogleMapAutocompleteService googleMapAutocompleteService) 
        : base(mapper, ctx, localizer) 
        {
            _googleMapAutocompleteService = googleMapAutocompleteService;
        }

    public override async Task<GetLocationsBySearchTextResponse> Execute(GetLocationsBySearchTextRequest request, 
        CancellationToken cancellationToken)
    {
        var googleMapListResponse = await _googleMapAutocompleteService
            .Search(request.SearchText, request.AcceptLanguage, cancellationToken);
        
        return _mapper.Map<GetLocationsBySearchTextResponse>(googleMapListResponse);
    }
}
