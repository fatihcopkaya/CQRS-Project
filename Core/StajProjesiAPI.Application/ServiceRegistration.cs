﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace StajProjesiAPI.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceRegistration));
            
        }
    }
}
