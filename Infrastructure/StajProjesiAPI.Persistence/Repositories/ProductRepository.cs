using StajProjesiAPI.Application.Abstract.Repositories;
using StajProjesiAPI.Domain.Entities;
using StajProjesiAPI.Persistence.Contexts;
using StajProjesiAPI.Persistence.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Persistence.Repositories
{
    public class ProductRepository : BaseRepository <Product>, IProductRepository
    {
        private readonly StajProjesiDbContext _context;


        public ProductRepository(StajProjesiDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddPhoto(ProductPhoto ProductPhoto)
        {
            
            _context.ProductPhotos.Add(ProductPhoto);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePhoto(ProductPhoto ProductPhoto)
        {
            
            _context.ProductPhotos.Remove(ProductPhoto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePhoto(ProductPhoto ProductPhoto)
        {
            
            _context.ProductPhotos.Update(ProductPhoto);
            await _context.SaveChangesAsync();
        }
    }
}
