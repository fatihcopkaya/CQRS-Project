using StajProjesiAPI.Application.BaseRepository;
using StajProjesiAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Application.Abstract.Repositories
{
     public interface IAppUserRepository : IBaseRepository<AppUser>
    {
    }
}
