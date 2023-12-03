using Microsoft.AspNetCore.Mvc;

namespace Application.Regions.Features.GetDistrictByName;

public record GetDistrictByNameInput
{
    [FromRoute(Name = "cityId")]
    public int CityId { get; set; }

    [FromRoute(Name = "districtName")]
    public string DistrictName { get; set; }
}