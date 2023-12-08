using System.Collections.Specialized;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Web;
using AutoMapper;
using Microsoft.Extensions.Options;

namespace Application.Commons.Services.MapService;

public class GoogleMapService : IMapService
{
    private readonly IMapper _mapper;
    private readonly MapSetting _mapSetting;

    public GoogleMapService(IMapper mapper, IOptions<MapSetting> mapSetting)
    {
        _mapper = mapper;
        _mapSetting = mapSetting.Value;
    }

    public async Task<List<LocationData>> GetLocations(string searchText, string acceptLanguage, 
        CancellationToken cancellationToken)
    {
        using HttpClient httpClient = new();
        httpClient.DefaultRequestHeaders.AcceptLanguage
            .Add(StringWithQualityHeaderValue.Parse(acceptLanguage));

        try
        {
            string autoCompleteUrl = BuilAutocompletedUrl(searchText);
            HttpResponseMessage response = await httpClient.GetAsync(autoCompleteUrl, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync(cancellationToken);
                var root = JsonSerializer.Deserialize<LocationDataRoot>(content);
                return root == null ? new List<LocationData>() : root.Data;
            }

            throw new Exception($"Failed to fetch the autocomplete list. Status code: {response.StatusCode}");
        }
        catch (Exception e)
        {
            throw new Exception($"Failed to fetch the autocomplete list. Exception: {e.Message}");
        }
    }

    public async Task<LocationDetailData> GetLocation(string locationId, CancellationToken cancellationToken)
    {
        using HttpClient httpClient = new();

        try
        {
            string placeUrl = BuildPlaceUrl(locationId);
            HttpResponseMessage response = await httpClient.GetAsync(placeUrl, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync(cancellationToken);
                var root = JsonSerializer.Deserialize<LocationDetailRoot>(content);
                return _mapper.Map<LocationDetailData>(root);
            }

            throw new Exception($"Failed to fetch the place list. Status code: {response.StatusCode}");
        }
        catch (Exception e)
        {
            throw new Exception($"Failed to fetch the place list. Exception: {e.Message}");
        }
    }

    private string BuilAutocompletedUrl(string searchText)
    {
        var query = new NameValueCollection
        {
            { "key", _mapSetting.GoogleMapApiKey },
            { "components", $"country:{_mapSetting.DefaultCountry}" },
            { "input", searchText }
        };

        string queryString = BuildQueryString(query);

        return _mapSetting.GoogleMapAutoCompleteApi + "?" + queryString;
    }

    private string BuildPlaceUrl(string locationId)
    {
        var query = new NameValueCollection
        {
            { "key", _mapSetting.GoogleMapApiKey },
            { "fields", "name,geometry,address_components" },
            { "place_id", locationId }
        };

        string queryString = BuildQueryString(query);

        return _mapSetting.GoogleMapPlaceApi + "?" + queryString;
    }

    private string BuildQueryString(NameValueCollection queryParameters)
    {
        var queryStringParts = new List<string>();

        foreach (string key in queryParameters.AllKeys)
        {
            string encodedKey = HttpUtility.UrlEncode(key);
            string encodedValue = HttpUtility.UrlEncode(queryParameters[key]);
            queryStringParts.Add($"{encodedKey}={encodedValue}");
        }

        return string.Join("&", queryStringParts);
    }
}
