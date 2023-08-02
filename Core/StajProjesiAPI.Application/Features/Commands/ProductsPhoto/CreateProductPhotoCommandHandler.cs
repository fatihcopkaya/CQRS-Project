using AutoMapper;
using MediatR;
using StajProjesiAPI.Application.Abstract.Services;
using StajProjesiAPI.Application.Dtos.ProductPhoto;
using StajProjesiAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Application.Features.Commands.ProductsPhoto
{
    public class CreateProductPhotoCommandHandler : IRequestHandler<CreateProductPhotoCommandRequest, CreateProductPhotoCommandResponse>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public CreateProductPhotoCommandHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<CreateProductPhotoCommandResponse> Handle(CreateProductPhotoCommandRequest request, CancellationToken cancellationToken)
        {
            
            var createProductPhoto = await _productService.AddPhoto(new ProductPhoto()
            {
                ProductId = request.ProductId,
                FileCode = request.FileCode,
                CreatedDate = DateTime.UtcNow,
                IsActive = true,
                
               
            });
            return new CreateProductPhotoCommandResponse() { IsSuccess = true};
        }
    }
}
