using Application.Commons.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Application.Regions.Features.GetDistrictsByCity;

public record GetDistrictsByCityIdRequest(int CityId) : BaseRequest<IdValueListResponse>;