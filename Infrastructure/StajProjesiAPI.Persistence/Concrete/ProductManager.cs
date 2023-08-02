using StajProjesiAPI.Application.Abstract.Repositories;
using StajProjesiAPI.Application.Abstract.Services;
using StajProjesiAPI.Application.Contacts;
using StajProjesiAPI.Application.Utilities.Result;
using StajProjesiAPI.Domain.Entities;

namespace StajProjesiAPI.Persistence.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IResult> AddPhoto(ProductPhoto productPhoto)
        {
           await _productRepository.AddPhoto(productPhoto);
            return new SuccessDataResult<ProductPhoto>(Messages.AddMessage);
        }

        public async Task<IDataResult<Product>> AddProduct(Product product)
        {
            await _productRepository.AddAsync(product);
            return new SuccessDataResult<Product>(product, Messages.AddMessage);
        }

        public async Task<IResult> DeletePhoto(ProductPhoto productPhoto)
        {
            await _productRepository.UpdatePhoto(productPhoto);
            return new SuccessDataResult<Product>(Messages.DeleteMessage);
        }

        public async Task<IResult> DeleteProduct(Product product)
        {
            await _productRepository.UpdateAsync(product);
            return new SuccessDataResult<Product>(Messages.DeleteMessage);
        }

        public async Task<IDataResult<List<Product>>> GetAllProducts()
        {
            return new SuccessDataResult<List<Product>>((await _productRepository.GetListAsync()).ToList());
        }

        public async Task<IDataResult<Product>> GetProductById(int ProductId)
        {
            var row = await _productRepository.GetFirstOrDefaultAsync(x=>x.Id == ProductId);
            if(row != null) 
            {
                return new SuccessDataResult<Product>(row);
            }
            return new ErrorDataResult<Product>(Messages.NoRecordMessage);
        }

        public async Task<IResult> UpdatePhoto(ProductPhoto productPhoto)
        {
            await _productRepository.UpdatePhoto(productPhoto);
            return new SuccessDataResult<Product>(Messages.UpdateMessage);

        }

        public async Task<IResult> UpdateProduct(Product product)
        {
            await _productRepository.UpdateAsync(product);
            return new SuccessDataResult<Product>(new Product(), Messages.UpdateMessage);
        }
    }
}
