using Microsoft.AspNetCore.Mvc;

namespace Application.Regions.Features.GetCitiesByStateId;

public record GetCitiesByStateIdInput
{
    [FromRoute(Name = "stateId")]
    public int StateId { get; set; }
};