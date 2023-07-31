using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StajProjesiAPI.Application.Features.Login;

namespace StajProjesi.API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(AppUserLoginCommandRequest appUserLoginCommandRequest)
        {
            AppUserLoginCommandResponse response = await _mediator.Send(appUserLoginCommandRequest);
            if(response.TokenVM == null)
            {
                return Unauthorized();
            }
            return Ok(response);

        
        }
    }
}
