

using MediatR;

namespace StajProjesiAPI.Application.Features.Commands.Products
{
    public class CreateProductCommandResponse : IRequest<CreateProductCommandRequest>
    {
        public bool IsSuccess { get; set; }
    }
}
