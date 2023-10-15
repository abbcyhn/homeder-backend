using Microsoft.AspNetCore.Mvc;

namespace Application.Regions.Features.GetCountryById;

public record GetCountryByIdInput
{
    [FromRoute(Name = "countryId")]
    public int CountryId { get; set; }
}
