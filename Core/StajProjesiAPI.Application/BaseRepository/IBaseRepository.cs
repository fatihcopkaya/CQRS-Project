using Microsoft.EntityFrameworkCore.Query;
using StajProjesiAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Application.BaseRepository
{
    public interface IBaseRepository<T> where T : class, IBaseEntity, new()
    {
        Task<T> GetAsync(int id);
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);
        Task<IList<T>> GetListAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
    }
}
