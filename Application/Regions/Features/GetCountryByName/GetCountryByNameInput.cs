using Microsoft.AspNetCore.Mvc;

namespace Application.Regions.Features.GetCountryByName;

public record GetCountryByNameInput
{
    [FromRoute(Name = "countryName")]
    public string? CountryName { get; set; }
}