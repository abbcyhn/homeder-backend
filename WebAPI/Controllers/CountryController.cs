using Application.Regions.Features.GetAllCountries;
using Application.Regions.Features.GetCountryById;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/countries")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class CountryController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public CountryController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet]
    [Route("{countryId}")]
    public async Task<IActionResult> GetCountryById([FromRoute] GetCountryByIdInput input, CancellationToken cancellationToken)
    {
        var request = _mapper.Map<GetCountryByIdRequest>(input);
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllCountries(CancellationToken cancellationToken)
    {
        var request = new GetAllCountriesRequest();
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}