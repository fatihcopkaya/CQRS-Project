using StajProjesiAPI.Application.BaseRepository;
using StajProjesiAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Application.Abstract.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task AddPhoto(ProductPhoto ProductPhoto);
        Task UpdatePhoto(ProductPhoto ProductPhoto);
        Task DeletePhoto(ProductPhoto ProductPhoto);
    }
}
