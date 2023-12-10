using Application.Commons.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Application.Regions.Features.GetLocationById;

public record GetLocationByIdInput : BaseInput
{
    [FromRoute(Name = "locationId")]
    public string LocationId { get; set; }
}