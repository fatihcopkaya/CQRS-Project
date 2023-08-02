using StajProjesiAPI.Application.Utilities.Result;
using StajProjesiAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Application.Abstract.Services
{
    public interface IProductService 
    {
        Task<IDataResult<Product>> AddProduct(Product product);
        Task<IDataResult<Product>> GetProductById(int ProductId);
        Task<IDataResult<List<Product>>> GetAllProducts();
        Task<IResult> UpdateProduct(Product product);
        Task<IResult> DeleteProduct(Product product);
        Task<IResult> AddPhoto(ProductPhoto productPhoto);
        Task<IResult> UpdatePhoto(ProductPhoto productPhoto);
        Task<IResult> DeletePhoto(ProductPhoto productPhoto);
    }
}
