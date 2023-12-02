using Microsoft.AspNetCore.Mvc;

namespace Application.Regions.Features.GetDistrictByName;

public record GetDistrictByNameInput([FromRoute(Name = "cityId")] int CityId,
    [FromRoute(Name = "districtName")] string DistrictName);