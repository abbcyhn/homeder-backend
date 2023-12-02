using Application.Commons.Mediator;

namespace Application.Regions.Features.GetDistrictByName;

public record GetDistrictByNameRequest(int CityId, string DistrictName) : BaseRequest<IdValueResponse>;