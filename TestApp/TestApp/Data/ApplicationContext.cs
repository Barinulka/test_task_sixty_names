using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TestApp.Models;
using System.Configuration;

namespace TestApp.Data
{
    public class ApplicationContext : DbContext
    {

        private string connectionString = ConfigurationManager.ConnectionStrings["ConsoleAppDB"].ConnectionString;

        public ApplicationContext()
        {
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // использование Fluent API
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<NaturalPerson> NaturalPersons { get; set; }
        public DbSet<LegalPerson> LegalPersons { get; set; }
        public DbSet<Contract> Contracts { get; set; }
    }
}
