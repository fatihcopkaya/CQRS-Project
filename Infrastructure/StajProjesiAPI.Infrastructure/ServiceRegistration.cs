using Microsoft.Extensions.DependencyInjection;
using StajProjesiAPI.Application.Abstract.Services;
using StajProjesiAPI.Infrastructure.Security.Hashing;
using StajProjesiAPI.Infrastructure.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddSecurityServices(this IServiceCollection services)
        {
            services.AddScoped<IHashingHelperService, HashingHelper>();
            services.AddScoped<JWTTokenService, JWTToken>();


        }
    }
}
