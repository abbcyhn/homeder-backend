using System.Text.Json.Serialization;
using Application.Commons.Mediator;

namespace Application.Commons.Services.MapService;

public record LocationIdValue
{
    [JsonPropertyName("place_id")]
    public string Id { get; set; }

    [JsonPropertyName("description")]
    public string Value { get; set; }
}

public record LocationIdValueList : BaseResponse
{
    [JsonPropertyName("predictions")]
    public List<LocationIdValue> Data { get; set; }
}
