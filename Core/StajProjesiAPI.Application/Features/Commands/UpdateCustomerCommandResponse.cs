using MediatR;

namespace StajProjesiAPI.Application.Features.Commands
{
    public class UpdateCustomerCommandResponse : IRequest<UpdateCustomerCommandRequest>
    {
        public  bool IsSuccess { get; set; }
        
    }
}
