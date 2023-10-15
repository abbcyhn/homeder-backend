using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class BaseController : ControllerBase
{
  protected readonly IMapper _mapper;
  protected readonly IMediator _mediator;

  public BaseController(IMapper mapper, IMediator mediator)
  {
    _mapper = mapper;
    _mediator = mediator;
  }
}
