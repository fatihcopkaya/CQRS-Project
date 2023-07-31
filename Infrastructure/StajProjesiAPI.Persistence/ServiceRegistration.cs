
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StajProjesiAPI.Application.Abstract.Repositories;
using StajProjesiAPI.Application.Abstract.Services;
using StajProjesiAPI.Application.Mapping;
using StajProjesiAPI.Persistence.Concrete;
using StajProjesiAPI.Persistence.Contexts;
using StajProjesiAPI.Persistence.Repositories;



namespace StajProjesiAPI.Persistence
{
    public static class ServiceRegistration
    {

        public static void AddPeristenceServices(this IServiceCollection services)
        {
            services.AddDbContext<StajProjesiDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerManager>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddHttpContextAccessor();

            services.AddAutoMapper(typeof(CustomerProfile));
        }
    }
}
