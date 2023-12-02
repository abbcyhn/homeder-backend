using Microsoft.AspNetCore.Mvc;

namespace Application.Regions.Features.GetCitiesByStateId;

public record GetCitiesByStateIdInput
{
    public int StateId { get; set; }
};