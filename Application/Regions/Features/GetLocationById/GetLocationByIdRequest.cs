using Application.Commons.Mediator;

namespace Application.Regions.Features.GetLocationById;

public record GetLocationByIdRequest : BaseRequest<GetLocationByIdResponse>
{
    public string LocationId { get; set; }
}