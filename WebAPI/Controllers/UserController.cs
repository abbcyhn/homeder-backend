using Application.Commons.Mediator;
using Application.Users.Features.CreateUser;
using Application.Users.Features.GetCitizenships;
using Application.Users.Features.GetTypes;
using Application.Users.Features.GetUserPhoto;
using Application.Users.Features.UpdateUser;
using Application.Users.Features.UpdateUserPhoto;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/users")]
public class UserController : BaseController
{
    public UserController(IMapper mapper, IMediator mediator) : base(mapper, mediator)
    {
    }

    [AllowAnonymous]
    [HttpPost("/api/login")]
    public async Task<ActionResult<string>> CreateUser([FromBody] CreateUserInput input, CancellationToken cancellationToken)
    {
        var request = _mapper.Map<CreateUserRequest>(input);
        
        var response = await _mediator.Send(request, cancellationToken);
        
        return Ok(response.HomederToken);
    }

    [HttpPut("{userId}")]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserInput input)
    {
        var request = _mapper.Map<UpdateUserRequest>(input);

        await _mediator.Send(request);

        return NoContent();
    }

    [HttpGet("{userId}/photo")]
    public async Task<IActionResult> GetUserPhoto([FromRoute] GetUserPhotoInput input, CancellationToken cancellationToken) 
    {
        var request = _mapper.Map<GetUserPhotoRequest>(input);

        var response = await _mediator.Send(request, cancellationToken);

        return File(response.UserPhoto, "image/png");
    }

    [HttpPost("{userId}/photo")]
    public async Task<ActionResult<string>> UpdateUserPhoto(UpdateUserPhotoInput input, CancellationToken cancellationToken)
    {
        var request = _mapper.Map<UpdateUserPhotoRequest>(input);
        
        var response = await _mediator.Send(request, cancellationToken);
        
        return Ok(response.PhotoUrl);
    }    
    
    [HttpGet("citizenships")]
    public async Task<ActionResult<IdValueListResponse>> GetCitizenships(CancellationToken cancellationToken)
    {
        var request = new GetCitizenshipsRequest();
        
        var response = await _mediator.Send(request, cancellationToken);
        
        return Ok(response);
    }
    
    [HttpGet("types")]
    public async Task<ActionResult<IdValueListResponse>> GetTypes(CancellationToken cancellationToken)
    {
        var request = new GetTypesRequest();
        
        var response = await _mediator.Send(request, cancellationToken);
        
        return Ok(response);
    }
}