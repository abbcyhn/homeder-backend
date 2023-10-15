using Application.Commons.Dtos;
using Application.Users.Features.CreateUser;
using Application.Users.Features.GetAllCitizenships;
using Application.Users.Features.GetAllTypes;
using Application.Users.Features.GetUserPhoto;
using Application.Users.Features.UpdateUser;
using Application.Users.Features.UpdateUserPhoto;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Extensions;

namespace WebAPI.Controllers;

[Route("api/users")]
public class UserController : BaseController
{
    public UserController(IMapper mapper, IMediator mediator) : base(mapper, mediator)
    {
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<string>> CreateUser([FromBody] CreateUserInput input, CancellationToken cancellationToken)
    {
        var request = _mapper.Map<CreateUserRequest>(input);
        request.HostUrl = HttpContext.Request.Host.Value;
        
        var response = await _mediator.Send(request, cancellationToken);
        
        return Ok(response.HomederToken);
    }


    [HttpPut("{userId}")]
    public async Task<IActionResult> UpdateUser(int userId, [FromBody] UpdateUserInput updateUserInput)
    {
        var request = _mapper.Map<UpdateUserRequest>(updateUserInput);
        request.UserId = userId;
        request.LoggedUserId = HttpContext.GetUserId();

        await _mediator.Send(request);

        return NoContent();
    }

    [HttpGet("{userId}/photo")]
    public async Task<IActionResult> GetUserPhoto(int userId, CancellationToken cancellationToken) 
    {
        var request = new GetUserPhotoRequest { UserId = userId, LoggedUserId = HttpContext.GetUserId() };

        var response = await _mediator.Send(request, cancellationToken);

        return File(response.UserPhoto, "image/png");
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