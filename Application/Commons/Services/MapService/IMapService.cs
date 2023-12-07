namespace Application.Commons.Services.MapService;

public interface IMapService
{
    Task<LocationDataIdValueList> SearchLocations(string searchText, string acceptLanguage, 
        CancellationToken cancellationToken);
}
