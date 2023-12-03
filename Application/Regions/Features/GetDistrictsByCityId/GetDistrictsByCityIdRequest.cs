using Application.Commons.Mediator;

namespace Application.Regions.Features.GetDistrictsByCityId;

public record GetDistrictsByCityIdRequest : BaseRequest<IdValueListResponse>
{
    public int CityId { get; set; }
}