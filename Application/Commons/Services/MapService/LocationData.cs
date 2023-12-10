using System.Text.Json.Serialization;

namespace Application.Commons.Services.MapService;

public record LocationData
{
    [JsonPropertyName("place_id")]
    public string Id { get; set; }

    [JsonPropertyName("description")]
    public string Value { get; set; }
}

public record LocationDataRoot
{
    [JsonPropertyName("predictions")]
    public List<LocationData> Data { get; set; }
}
