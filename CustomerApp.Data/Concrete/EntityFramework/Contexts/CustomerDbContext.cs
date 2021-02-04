using System;
using CustomerApp.Data.Concrete.EntityFramework.Mappings;
using CustomerApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CustomerApp.Data.Concrete.EntityFramework.Contexts
{
    public class CustomerDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: "Server=localhost;Database=CustomersApp;User Id=sa;Password=DockerSa@2017;");

        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());
        }
    }
}
