using Application.Commons.Mediator;

namespace Application.Regions.Features.GetStateByName;

public record GetStateByNameRequest : BaseRequest<IdValueResponse>
{
    public int CountryId { get; set; }
    public string StateName { get; set; }
}