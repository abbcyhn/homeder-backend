using Application.Commons.Mediator;

namespace Application.Regions.Features.GetDistrictsByCity;

public record GetDistrictsByCityIdRequest : BaseRequest<IdValueListResponse>
{
    public int CityId { get; set; }
}