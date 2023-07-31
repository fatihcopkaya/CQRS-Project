using Microsoft.EntityFrameworkCore;
using StajProjesiAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Persistence.Contexts
{
    public class StajProjesiDbContext : DbContext
    {
        public StajProjesiDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<AppUser>AppUsers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }


    }
}
