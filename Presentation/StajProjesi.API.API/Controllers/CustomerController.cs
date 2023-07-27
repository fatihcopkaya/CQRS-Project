using MediatR;
using Microsoft.AspNetCore.Mvc;
using StajProjesiAPI.Application.Features.Commands;
using StajProjesiAPI.Application.Features.Queries;


namespace StajProjesi.API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerCommandRequest createCustomerCommandRequest)
        {
            CreateCustomerCommandResponse response = await _mediator.Send(createCustomerCommandRequest);
            return Ok(response);

        }
        [HttpGet("GetCustomerById")]
        public async Task<IActionResult>GetCustomerById([FromQuery]GetCustomerByIdQueryRequest getCustomerByIdQueryRequest)
        {
            GetCustomerByIdQueryResponse response = await _mediator.Send(getCustomerByIdQueryRequest); 
            return Ok(response);

        }
        [HttpGet("GetCustomerList")]
        public async Task<IActionResult> CustomerList([FromQuery]GetAllCustomerQueryRequest getAllCustomerQueryRequest)
        {
            var response = await _mediator.Send(getAllCustomerQueryRequest);
            return Ok(response);

        }
        [HttpPost("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer([FromQuery]UpdateCustomerCommandRequest updateCustomerCommandRequest)
        {
            var response = await _mediator.Send(updateCustomerCommandRequest);
            return Ok(response);

        }
    }
}
