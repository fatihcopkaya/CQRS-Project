using StajProjesiAPI.Application.Abstract;
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
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(StajProjesiDbContext context) : base(context)
        {
        }
    }
}
