using Microsoft.AspNetCore.Mvc;

namespace Application.Regions.Features.GetStatesByCountryId;

public record GetStatesByCountryIdInput
{
    [FromRoute(Name = "countryId")]
    public int CountryId { get; set; }
};