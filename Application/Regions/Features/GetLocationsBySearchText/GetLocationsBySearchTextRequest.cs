using Application.Commons.Mediator;

namespace Application.Regions.Features.GetLocationsBySearchText;

public record GetLocationsBySearchTextRequest : BaseRequest<GetLocationsBySearchTextResponse>
{
    public string SearchText { get; set; }
}
