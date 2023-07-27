using StajProjesiAPI.Application.Abstract;
using StajProjesiAPI.Application.Abstract.Repositories;
using StajProjesiAPI.Domain.Entities;
using StajProjesiAPI.Persistence.Contexts;
using StajProjesiAPI.Persistence.Repositories.BaseRepository;

namespace StajProjesiAPI.Persistence.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(StajProjesiDbContext context) : base(context)
        {
        }
    }
}
