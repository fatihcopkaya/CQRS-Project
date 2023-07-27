using MediatR;

namespace StajProjesiAPI.Application.Features.Commands
{
    public class CreateCustomerCommandResponse : IRequest<CreateCustomerCommandRequest>
    {
        public bool IsSuccess { get; set; }
        
    }
}
