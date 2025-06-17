using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.DAL.Configuration;
using Shop.DAL.Entities;

namespace Shop.DAL.Context
{
    public class AppilcationDbContext : DbContext
    {
        public AppilcationDbContext(DbContextOptions<AppilcationDbContext> options) : base(options)
        {
        }
        
        // DbSet properties for each entity in the context
        // This allows us to query and save instances of these entities
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Apply configurations from the assembly 
            // this allows us to keep our entity configurations in separate files
            // and automatically apply them without needing to manually add each one
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
