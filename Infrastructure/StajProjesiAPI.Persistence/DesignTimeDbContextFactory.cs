using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using StajProjesiAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<StajProjesiDbContext>
    {
        public StajProjesiDbContext CreateDbContext(string[] args)
        {
            
            DbContextOptionsBuilder<StajProjesiDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
            return new StajProjesiDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
