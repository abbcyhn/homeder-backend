namespace Application.Commons.Services.MapService;

public interface IMapService
{
    Task<LocationIdValueList> SearchLocations(string searchText, string acceptLanguage, 
        CancellationToken cancellationToken);
}
