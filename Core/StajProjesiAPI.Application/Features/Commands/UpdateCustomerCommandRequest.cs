using MediatR;
namespace StajProjesiAPI.Application.Features.Commands
{
    public class UpdateCustomerCommandRequest : IRequest<UpdateCustomerCommandResponse>
    {
        public string Name { get; set;}
        public int Id { get; set; }
    }
}
