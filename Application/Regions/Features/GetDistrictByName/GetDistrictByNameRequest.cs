using Application.Commons.Mediator;

namespace Application.Regions.Features.GetDistrictByName;

public record GetDistrictByNameRequest : BaseRequest<IdValueResponse>
{
    public int CityId { get; set; }
    public string DistrictName { get; set; }
}