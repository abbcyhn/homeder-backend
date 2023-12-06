namespace Application.Regions.Features.GetLocationsBySearchText.Services;

public interface IMapService
{
    Task<LocationIdValueList> SearchLocations(string searchText, string acceptLanguage, 
        CancellationToken cancellationToken);
}
