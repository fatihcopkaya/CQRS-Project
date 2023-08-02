

using MediatR;
using StajProjesiAPI.Application.Dtos.Product;

namespace StajProjesiAPI.Application.Features.Commands.Products
{
    public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
    {
        public CreateProductDto CreateProductDto { get; set; }
       
    }
}
