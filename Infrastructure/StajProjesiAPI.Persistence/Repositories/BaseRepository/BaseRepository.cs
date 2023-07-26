using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using StajProjesiAPI.Application.BaseRepository;
using StajProjesiAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using StajProjesiAPI.Persistence.Contexts;

namespace StajProjesiAPI.Persistence.Repositories.BaseRepository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IBaseEntity, new()
    {
        private readonly StajProjesiDbContext _context;

        public BaseRepository(StajProjesiDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> GetAsync(int id)
        {
           
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            
            IQueryable<TEntity> queryable = _context.Set<TEntity>();
            if (filter != null)
            {
                queryable = queryable.Where(filter);

            }
            if (include != null)
            {
                queryable = include(queryable);
            }
            return await queryable.AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            
            IQueryable<TEntity> queryable = _context.Set<TEntity>();
            if (filter != null)
            {
                queryable = queryable.Where(filter);
            }
            if (includes != null)
            {
                foreach (Expression<Func<TEntity, object>> include in includes)
                {
                    queryable = queryable.Include(include);

                }
            }
            return await queryable.FirstOrDefaultAsync();


        }

        public async Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includes != null)
            {
                foreach (Expression<Func<TEntity, object>> include in includes)
                {
                    query = query.Include(include);
                }
            }
            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            return await query.ToListAsync();
        }

        public async Task RemoveAsync(TEntity entity)
        {
            
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
