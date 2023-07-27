using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using StajProjesiAPI.Persistence.Contexts;


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
