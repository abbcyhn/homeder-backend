using Application.Commons.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Application.Regions.Features.GetLocationsBySearchText;

public record GetLocationsBySearchTextInput : BaseInput
{
    [FromQuery(Name = "q")]
    public string? SearchText { get; set; }
}
