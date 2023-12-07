using System.Text.Json.Serialization;
using Application.Commons.Mediator;

namespace Application.Commons.Services.MapService;

public record LocationDataIdValue
{
    [JsonPropertyName("place_id")]
    public string Id { get; set; }

    [JsonPropertyName("description")]
    public string Value { get; set; }
}

public record LocationDataIdValueList : BaseResponse
{
    [JsonPropertyName("predictions")]
    public List<LocationDataIdValue> Data { get; set; }
}
