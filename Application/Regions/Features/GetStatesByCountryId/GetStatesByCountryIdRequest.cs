using Application.Commons.Mediator;

namespace Application.Regions.Features.GetStatesByCountryId;

public record GetStatesByCountryIdRequest : BaseRequest<IdValueListResponse>
{
    public int CountryId { get; set; }
};