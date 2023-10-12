using Application.Users.Features.CreateUser;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
}
