using Application.Commons.Mediator;
using Application.Regions.Features.GetAllCountryCodes;
using Application.Regions.Features.GetCountries;
using Application.Regions.Features.GetCountryById;
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

    [HttpGet("countries/{countryId}")]
    public async Task<ActionResult<IdValueResponse>> GetCountryById([FromRoute] GetCountryByIdInput input, CancellationToken cancellationToken)
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