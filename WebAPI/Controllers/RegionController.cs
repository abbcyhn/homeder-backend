using Application.Commons.Dtos;
using Application.Regions.Features.GetAllCountries;
using Application.Regions.Features.GetAllCountryCodes;
using Application.Regions.Features.GetCountryById;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/regions")]
[ApiController]
// [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class RegionController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public RegionController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet("countries/{countryId}")]
    public async Task<ActionResult<GetLibResponse>> GetCountryById([FromRoute] GetCountryByIdInput input, CancellationToken cancellationToken)
    {
        var request = _mapper.Map<GetCountryByIdRequest>(input);
        
        var response = await _mediator.Send(request, cancellationToken);
        
        return Ok(response);
    }

    [HttpGet("countries")]
    public async Task<ActionResult<GetAllLibResponse>> GetAllCountries(CancellationToken cancellationToken)
    {
        var request = new GetAllCountriesRequest();
        
        var response = await _mediator.Send(request, cancellationToken);
        
        return Ok(response);
    }
    
    [HttpGet("country-codes")]
    public async Task<ActionResult<GetAllLibResponse>> GetAllCountryCodes(CancellationToken cancellationToken)
    {
        var request = new GetAllCountryCodesRequest();
        
        var response = await _mediator.Send(request, cancellationToken);
        
        return Ok(response);
    }
}