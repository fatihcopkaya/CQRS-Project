using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StajProjesiAPI.Application.Features.Commands;

namespace StajProjesi.API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppUserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("CreateAppUser")]
        public async Task<IActionResult> CreateAppUser(CreateAppUserCommandRequest createAppUserCommandRequest)
        {
            CreateAppUserCommandResponse response = await _mediator.Send(createAppUserCommandRequest);
            return Ok(response);

        }
        [HttpPost("UpdateAppUser")]
        public async Task<IActionResult> UpdateAppUser(UpdateAppUserCommandRequest updateAppUserCommandRequest)
        {
            UpdateAppUserCommandResponse response = await _mediator.Send(updateAppUserCommandRequest);
            return Ok(response);
            

        }
    }
}
