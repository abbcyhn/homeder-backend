using System.Text.Json.Serialization;
using Application.Commons.Mediator;

namespace Application.Regions.Features.GetLocationsBySearchText.Services;

public record GoogleMapIdValue
{
    [JsonPropertyName("place_id")]
    public string Id { get; set; }

    [JsonPropertyName("description")]
    public string Value { get; set; }
}

public record GoogleMapIdValueList : BaseResponse
{
    [JsonPropertyName("predictions")]
    public List<GoogleMapIdValue> Data { get; set; }
}
