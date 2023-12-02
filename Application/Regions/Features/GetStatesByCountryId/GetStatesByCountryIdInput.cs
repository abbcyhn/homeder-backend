using Microsoft.AspNetCore.Mvc;

namespace Application.Regions.Features.GetStatesByCountryId;

public record GetStatesByCountryIdInput
{
    public int CountryId { get; set; }
};