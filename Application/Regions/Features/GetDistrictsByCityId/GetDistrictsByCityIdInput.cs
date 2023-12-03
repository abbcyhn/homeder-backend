using Microsoft.AspNetCore.Mvc;

namespace Application.Regions.Features.GetDistrictsByCity;

public record GetDistrictsByCityIdInput
{
    [FromRoute(Name = "cityId")]
    public int CityId { get; set; }
}