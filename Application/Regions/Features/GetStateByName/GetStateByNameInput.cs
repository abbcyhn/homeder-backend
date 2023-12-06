using Microsoft.AspNetCore.Mvc;

namespace Application.Regions.Features.GetStateByName;

public record GetStateByNameInput
{
    [FromRoute(Name = "countryId")]
    public int CountryId { get; set; }
    [FromRoute(Name = "stateName")]
    public string? StateName { get; set; }
}