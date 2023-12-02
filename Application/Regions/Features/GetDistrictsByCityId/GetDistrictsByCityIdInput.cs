using Microsoft.AspNetCore.Mvc;

namespace Application.Regions.Features.GetDistrictsByCity;

public record GetDistrictsByCityIdInput([FromRoute] int CityId);