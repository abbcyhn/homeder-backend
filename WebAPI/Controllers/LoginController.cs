using Application.Users.Features.CreateUser;
using Application.Users.Features.UpdateUserPhoto;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Extensions;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/login")]
public class LoginController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public LoginController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }


    [HttpPost]
    [Route("")]
    public async Task<IActionResult> LoginViaGoogle([FromBody] CreateUserInput input, CancellationToken cancellationToken)
    {
        var request = _mapper.Map<CreateUserRequest>(input);
        request.HostUrl = HttpContext.Request.Host.Value;
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response.HomederToken);
    }

    // MOTE TO USERCONTROLLER
    [HttpPost]
    [Route("{userId}/photo")]
    public async Task<IActionResult> UpdateUserPhoto([FromRoute] int userId, UpdateUserPhotoInput input, CancellationToken cancellationToken)
    {
        var request = _mapper.Map<UpdateUserPhotoRequest>(input);
        request.UserId = userId;
        request.LoggedUserId = HttpContext.GetUserId();
        request.HostUrl = HttpContext.Request.Host.Value;
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response.PhotoUrl);
    }    
}
