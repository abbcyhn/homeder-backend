using Application.Commons.Dtos;
using Application.Users.Features.CreateUser;
using Application.Users.Features.GetAllCitizenships;
using Application.Users.Features.GetAllTypes;
using Application.Users.Features.UpdateUser;
using Application.Users.Features.UpdateUserPhoto;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Extensions;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/users")]
// [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public UserController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    
    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<string>> LoginViaGoogle([FromBody] CreateUserInput input, CancellationToken cancellationToken)
    {
        var request = _mapper.Map<CreateUserRequest>(input);
        request.HostUrl = HttpContext.Request.Host.Value;
        
        var response = await _mediator.Send(request, cancellationToken);
        
        return Ok(response.HomederToken);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateUserInput updateUserInput)
    {
        var request = _mapper.Map<UpdateUserRequest>(updateUserInput);
        request.Id = id;
        var response = await _mediator.Send(request);

        if (response)
        {
            return NoContent();
        }
        
        return Conflict();
    }

    [HttpPost("{userId}/photo")]
    public async Task<ActionResult<string>> UpdateUserPhoto([FromRoute] int userId, UpdateUserPhotoInput input,
        CancellationToken cancellationToken)
    {
        var request = _mapper.Map<UpdateUserPhotoRequest>(input);
        request.UserId = userId;
        request.LoggedUserId = HttpContext.GetUserId();
        request.HostUrl = HttpContext.Request.Host.Value;
        
        var response = await _mediator.Send(request, cancellationToken);
        
        return Ok(response.PhotoUrl);
    }    
    
    [HttpGet("citizenships")]
    public async Task<ActionResult<GetAllLibResponse>> GetAllCitizenships(CancellationToken cancellationToken)
    {
        var request = new GetAllCitizenshipsRequest();
        
        var response = await _mediator.Send(request, cancellationToken);
        
        return Ok(response);
    }
    
    [HttpGet("types")]
    public async Task<ActionResult<GetAllLibResponse>> GetAllTypes(CancellationToken cancellationToken)
    {
        var request = new GetAllTypesRequest();
        
        var response = await _mediator.Send(request, cancellationToken);
        
        return Ok(response);
    }
}