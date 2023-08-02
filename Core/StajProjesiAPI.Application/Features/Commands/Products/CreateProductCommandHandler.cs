using AutoMapper;
using MediatR;
using StajProjesiAPI.Application.Abstract.Services;
using StajProjesiAPI.Application.Dtos.Product;
using StajProjesiAPI.Application.Dtos.ProductPhoto;
using StajProjesiAPI.Application.Features.Commands.Documents;
using StajProjesiAPI.Application.Features.Commands.ProductsPhoto;
using StajProjesiAPI.Application.Features.Queries;
using StajProjesiAPI.Domain.Entities;

namespace StajProjesiAPI.Application.Features.Commands.Products
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IProductService _productService;
        private readonly IDocumentService _documentService;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateProductCommandHandler(IProductService productService, IDocumentService documentService, IMapper mapper, IMediator mediator)
        {
            _productService = productService;
            _documentService = documentService;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var AppUserQuery = new GetAuthenticatedUserQueryRequest();
            var authenticatedUserResponse = await _mediator.Send(AppUserQuery);
            if (authenticatedUserResponse.AppUser != null) 
            {
                var DocumentCommand = new CreateDocumentCommandRequest() {file = request.CreateProductDto.FileCode};
                var createDocumentCommandResponse = await _mediator.Send(DocumentCommand);

                if(createDocumentCommandResponse.FileCode != null)
                {
                    var mappedProduct = _mapper.Map<CreateProductDto, Product>(request.CreateProductDto,new Product());
                    mappedProduct.AppUserId = authenticatedUserResponse.AppUser.Id;
                    var createdProduct = await _productService.AddProduct(mappedProduct);
                    if(createdProduct.Success)
                    {
                        
                        var productPhotoQuery = new CreateProductPhotoCommandRequest(){ FileCode =createDocumentCommandResponse.FileCode,ProductId = createdProduct.Data.Id };
                        var productPhotoResponse = await _mediator.Send(productPhotoQuery);
                        return new CreateProductCommandResponse { IsSuccess = true };
                    }

                }
                return new CreateProductCommandResponse { IsSuccess = false };


            }
            return new CreateProductCommandResponse { IsSuccess = false };

        }
    }
}
