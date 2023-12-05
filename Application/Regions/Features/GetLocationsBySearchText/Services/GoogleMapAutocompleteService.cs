using System.Collections.Specialized;
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.Extensions.Options;

namespace Application.Regions.Features.GetLocationsBySearchText.Services;

public class GoogleMapAutocompleteService : IGoogleMapAutocompleteService
{
    private readonly MapSetting _mapSetting;

    public GoogleMapAutocompleteService(IOptions<MapSetting> mapSetting)
    {
        _mapSetting = mapSetting.Value;
    }

    public async Task<GoogleMapIdValueList> Search(string searchText, string acceptLanguage, 
        CancellationToken cancellationToken)
    {
        using HttpClient httpClient = new();
        httpClient.DefaultRequestHeaders.AcceptLanguage
            .Add(StringWithQualityHeaderValue.Parse(acceptLanguage));

        try
        {
            string autoCompleteUrl = BuildUrl(searchText);
            HttpResponseMessage response = await httpClient.GetAsync(autoCompleteUrl, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync(cancellationToken);
                return JsonSerializer.Deserialize<GoogleMapIdValueList>(content);
            }

            throw new Exception($"Failed to fetch the autocomplete list. Status code: {response.StatusCode}");
        }
        catch (Exception e)
        {
            throw new Exception($"Failed to fetch the autocomplete list. Exception: {e.Message}");
        }
    }

    private string BuildUrl(string searchText)
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

    private string BuildQueryString(NameValueCollection queryParameters)
    {
        var queryStringParts = new List<string>();

        foreach (string key in queryParameters.AllKeys)
        {
            string encodedKey = System.Web.HttpUtility.UrlEncode(key);
            string encodedValue = System.Web.HttpUtility.UrlEncode(queryParameters[key]);
            queryStringParts.Add($"{encodedKey}={encodedValue}");
        }

        return string.Join("&", queryStringParts);
    }
}
