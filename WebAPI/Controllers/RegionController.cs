using Application.Commons.Mediator;
using Application.Regions.Features.GetCountries;
using Application.Regions.Features.GetCountryById;
using Application.Regions.Features.GetCountryByName;
using Application.Regions.Features.GetCountryCodes;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/regions")]
public class RegionController : BaseController
{
    public RegionController(IMapper mapper, IMediator mediator) : base(mapper, mediator)
    {
    }

    [HttpGet("countries/{countryName}")]
    public async Task<ActionResult<IdValueResponse>> GetCountryByName([FromRoute] GetCountryByNameInput input,
        CancellationToken cancellationToken)
    {
        var request = _mapper.Map<GetCountryByNameRequest>(input);

        var response = await _mediator.Send(request, cancellationToken);

        return Ok(response);
    }

    [HttpGet("countries/{countryId:int}")]
    public async Task<ActionResult<IdValueResponse>> GetCountryById([FromRoute] GetCountryByIdInput input,
        CancellationToken cancellationToken)
    {
        var request = _mapper.Map<GetCountryByIdRequest>(input);

        var response = await _mediator.Send(request, cancellationToken);

        return Ok(response);
    }

    [HttpGet("countries")]
    public async Task<ActionResult<IdValueListResponse>> GetAllCountries(CancellationToken cancellationToken)
    {
        var request = new GetCountriesRequest();

        var response = await _mediator.Send(request, cancellationToken);

        return Ok(response);
    }

    [HttpGet("country-codes")]
    public async Task<ActionResult<IdValueListResponse>> GetAllCountryCodes(CancellationToken cancellationToken)
    {
        var request = new GetAllCountryCodesRequest();

        var response = await _mediator.Send(request, cancellationToken);

        return Ok(response);
    }
}