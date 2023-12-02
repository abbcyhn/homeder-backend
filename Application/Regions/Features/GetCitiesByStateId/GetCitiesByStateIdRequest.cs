using Application.Commons.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Application.Regions.Features.GetCitiesByStateId;

public record GetCitiesByStateIdRequest(int StateId) : BaseRequest<IdValueListResponse>;