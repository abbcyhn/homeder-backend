using Application.Commons.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Application.Regions.Features.GetCitiesByStateId;

public record GetCitiesByStateIdRequest : BaseRequest<IdValueListResponse>
{
    public int StateId { get; set; }
};