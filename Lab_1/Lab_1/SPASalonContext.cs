using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Lab_1
{
    public class SPASalonContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<TypeOfService> TypeOfServices { get; set; }
        public DbSet<CustomerService> CustomerServices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptions)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("AppSettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("SQLConnection");
            var options = dbContextOptions
                .UseSqlServer(connectionString)
                .Options;
        }
    }
}
