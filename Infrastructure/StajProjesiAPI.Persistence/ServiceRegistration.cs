
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
            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddHttpContextAccessor();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IDocumentService, DocumentManager>();

            services.AddAutoMapper(typeof(AppUserProfile));
        }
    }
}
