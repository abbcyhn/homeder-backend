using System.Text.Json.Serialization;

namespace Application.Commons.Services.MapService;

public record LocationDetailData
{
    public string CountryName { get; set; }
    public string StateName { get; set; }
    public string CityName { get; set; }
    public string DistrictName  { get; set; }
    public string Street  { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
}

public record LocationDetailRoot
{
    [JsonPropertyName("result")]
    public LocationDetailResult Result { get; set; }
}

public record LocationDetailResult
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("geometry")]
    public LocationDetailGeometry Geometry { get; set; }

    [JsonPropertyName("address_components")]
    public List<LocationDetailComponent> Components { get; set; }
}

public record LocationDetailComponent
{
    [JsonPropertyName("long_name")]
    public string LongName { get; set; }

    [JsonPropertyName("short_name")]
    public string ShortName { get; set; }

    [JsonPropertyName("types")]
    public List<string> Types { get; set; }
}

public record LocationDetailGeometry
{
    [JsonPropertyName("location")]
    public LocationDetailGeometryLocation Location { get; set; }
}

public record LocationDetailGeometryLocation
{
    [JsonPropertyName("lat")]
    public decimal Latitude { get; set; }

    [JsonPropertyName("lng")]
    public decimal Longitude { get; set; }
}