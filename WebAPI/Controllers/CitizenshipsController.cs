using Application.Regions.Features.GetAllCitizenships;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/citizenships")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CitizenshipsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CitizenshipsController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllCountries(CancellationToken cancellationToken)
        {
            var request = new GetAllCitizenshipsRequest();
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
