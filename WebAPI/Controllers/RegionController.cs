using Application.Commons.Mediator;
using Application.Regions.Features.GetCitiesByStateId;
using Application.Regions.Features.GetCityByName;
using Application.Regions.Features.GetCountries;
using Application.Regions.Features.GetCountryById;
using Application.Regions.Features.GetCountryByName;
using Application.Regions.Features.GetCountryCodes;
using Application.Regions.Features.GetDistrictsByCity;
using Application.Regions.Features.GetDistrictByName;
using Application.Regions.Features.GetStateByName;
using Application.Regions.Features.GetStatesByCountryId;
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

    [HttpGet("country-codes")]
    public async Task<ActionResult<IdValueListResponse>> GetCountryCodes(CancellationToken cancellationToken)
    {
        var request = new GetAllCountryCodesRequest();

        var response = await _mediator.Send(request, cancellationToken);

        return Ok(response);
    }


    [HttpGet("countries")]
    public async Task<ActionResult<IdValueListResponse>> GetCountries(CancellationToken cancellationToken)
    {
        var request = new GetCountriesRequest();

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

    [HttpGet("countries/{countryName}")]
    public async Task<ActionResult<IdValueResponse>> GetCountryByName([FromRoute] GetCountryByNameInput input,
        CancellationToken cancellationToken)
    {
        var request = _mapper.Map<GetCountryByNameRequest>(input);

        var response = await _mediator.Send(request, cancellationToken);

        return Ok(response);
    }

    [HttpGet("countries/{countryId:int}/states")]
    public async Task<ActionResult<IdValueResponse>> GetStates([FromRoute] GetStatesByCountryIdInput input, CancellationToken cancellationToken)
    {
        var request = _mapper.Map<GetStatesByCountryIdRequest>(input);

        var response = await _mediator.Send(request, cancellationToken);

        return Ok(response);
    }

    [HttpGet("countries/{countryId:int}/states/{stateName}")]
    public async Task<ActionResult<IdValueResponse>> GetStateByName([FromRoute] GetStateByNameInput input,
        CancellationToken cancellationToken)
    {
        var request = _mapper.Map<GetStateByNameRequest>(input);

        var response = await _mediator.Send(request, cancellationToken);

        return Ok(response);
    }

    [HttpGet("states/{stateId}/cities")]
    public async Task<ActionResult<IdValueResponse>> GetCitiesByStateId([FromRoute] GetCitiesByStateIdInput input, CancellationToken cancellationToken)
    {
        var request = _mapper.Map<GetCitiesByStateIdRequest>(input);

        var response = await _mediator.Send(request, cancellationToken);

        return Ok(response);
    }

    [HttpGet("states/{stateId}/cities/{cityName}")]
    public async Task<ActionResult<IdValueResponse>> GetCityByName([FromRoute] GetCityByNameInput input, CancellationToken cancellationToken)
    {
        var request = _mapper.Map<GetCityByNameRequest>(input);

        var response = await _mediator.Send(request, cancellationToken);

        return Ok(response);
    }

    [HttpGet("cities/{cityId}/districts/{districtName}")]
    public async Task<ActionResult<IdValueResponse>> GetDistrictByName([FromRoute] GetDistrictByNameInput input,
        CancellationToken cancellationToken)
    {
        var request = _mapper.Map<GetDistrictByNameRequest>(input);

        var response = await _mediator.Send(request, cancellationToken);

        return Ok(response);
    }

    [HttpGet("cities/{cityId}/districts")]
    public async Task<ActionResult<IdValueListResponse>> GetDistrictsByCityId([FromRoute] GetDistrictsByCityIdInput idInput, CancellationToken cancellationToken)
    {
        var request = _mapper.Map<GetDistrictsByCityIdRequest>(idInput);

        var response = await _mediator.Send(request, cancellationToken);

        return Ok(response);
    }
}