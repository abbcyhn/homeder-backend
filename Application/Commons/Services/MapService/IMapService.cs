namespace Application.Commons.Services.MapService;

public interface IMapService
{
    Task<List<LocationData>> GetLocations(string searchText, string acceptLanguage, 
        CancellationToken cancellationToken);
    
    Task<LocationDetailData> GetLocation(string locationId, CancellationToken cancellationToken);
}
