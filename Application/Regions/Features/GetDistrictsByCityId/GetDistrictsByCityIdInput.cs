using Microsoft.AspNetCore.Mvc;

namespace Application.Regions.Features.GetDistrictsByCityId;

public record GetDistrictsByCityIdInput
{
    [FromRoute(Name = "cityId")]
    public int CityId { get; set; }
}