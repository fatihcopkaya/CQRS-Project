using MediatR;
using StajProjesiAPI.Domain.Dtos.Customer;


namespace StajProjesiAPI.Application.Features.Commands
{
    public class CreateCustomerCommandRequest : IRequest<CreateCustomerCommandResponse>
    {
        public CustomerDTO CustomerDto { get; set; }
    }
}
