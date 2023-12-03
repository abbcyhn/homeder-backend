using Microsoft.AspNetCore.Mvc;

namespace Application.Regions.Features.GetCityByName;

public record GetCityByNameInput
{
    [FromRoute(Name = "stateId")]
    public int StateId { get; set; }
    
    [FromRoute(Name = "cityName")]
    public string? CityName { get; set; }
};