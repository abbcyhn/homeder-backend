using Microsoft.AspNetCore.Mvc;

namespace Application.Regions.Features.GetStateByName;

public record GetStateByNameInput
{
    public int CountryId { get; set; }
    
    public string? StateName { get; set; }
}