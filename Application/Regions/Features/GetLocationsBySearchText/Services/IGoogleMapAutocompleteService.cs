namespace Application.Regions.Features.GetLocationsBySearchText.Services;

public interface IGoogleMapAutocompleteService
{
    Task<GoogleMapIdValueList> Search(string searchText, string acceptLanguage, 
        CancellationToken cancellationToken);
}
