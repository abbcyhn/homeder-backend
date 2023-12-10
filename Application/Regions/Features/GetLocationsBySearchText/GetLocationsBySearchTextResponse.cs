using Application.Commons.Mediator;

namespace Application.Regions.Features.GetLocationsBySearchText;

public record GetLocationsBySearchTextResponse : BaseResponse
{
    public List<GetLocationsBySearchTextIdValueDto> Data { get; set; } = new List<GetLocationsBySearchTextIdValueDto>();
}

public record GetLocationsBySearchTextIdValueDto
{
    public string Id { get; set; }
    public string Value { get; set; }
}