using Azure;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Diagnostics.Metrics;
using System.Net;
using System.Reflection;
using TestApp.Models;

namespace TestApp.Data
{
    public class ApplicationContext : DbContext
    {

        private string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnect"].ConnectionString;

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NaturalPerson>().HasData(
                new NaturalPerson { Id = 1, FirstName = "Петр", LastName = "Петрович", Patronymic = "Петров", Gender = "male", Age = 25, Place = "some place", Country = "Россия", City = "Самара", Address = "some address", Email = "email@email.com", Phone = "+79372110710", Birthday = DateTime.ParseExact("1993-01-16", "yyyy-MM-dd", null) },
                new NaturalPerson { Id = 2, FirstName = "Петр", LastName = "Петрович", Patronymic = "Петров", Gender = "male", Age = 35, Place = "some place", Country = "Россия", City = "Казань", Address = "some address", Email = "email1@email.com", Phone = "+79372110710", Birthday = DateTime.ParseExact("1993-01-16", "yyyy-MM-dd", null) },
                new NaturalPerson { Id = 3, FirstName = "Петр", LastName = "Петрович", Patronymic = "Петров", Gender = "male", Age = 65, Place = "some place", Country = "Беларусь", City = "Минск", Address = "some address", Email = "email2@email.com", Phone = "+79372110710", Birthday = DateTime.ParseExact("1993-01-16", "yyyy-MM-dd", null) },
                new NaturalPerson { Id = 4, FirstName = "Петр", LastName = "Петрович", Patronymic = "Петров", Gender = "male", Age = 55, Place = "some place", Country = "Россия", City = "Москва", Address = "some address", Email = "email3@email.com", Phone = "+79372110710", Birthday = DateTime.ParseExact("1993-01-16", "yyyy-MM-dd", null) }
            );
            modelBuilder.Entity<LegalPerson>().HasData(
                new LegalPerson { Id = 1, Name = "OOO 1", Inn = 11, Ogrn = 11, Country = "Россия", City = "Самара", Address = "some address", Phone = "+79372110710", Email = "email2@email.com" },
               new LegalPerson { Id = 2, Name = "OOO 1", Inn = 11, Ogrn = 11, Country = "Россия", City = "Казань", Address = "some address", Phone = "+79372110710", Email = "email2@email.com" },
               new LegalPerson { Id = 3, Name = "OOO 1", Inn = 11, Ogrn = 11, Country = "Беларусь", City = "Минск", Address = "some address", Phone = "+79372110710", Email = "email2@email.com" },
               new LegalPerson { Id = 4, Name = "OOO 1", Inn = 11, Ogrn = 11, Country = "Россия", City = "Москва", Address = "some address", Phone = "+79372110710", Email = "email2@email.com" }
            );
            modelBuilder.Entity<Contract>().HasData(
                new Contract { Id = 1, NaturalPersonId = 1, LegalPersonId = 0, Date = DateTime.ParseExact("2023-04-10", "yyyy-MM-dd", null), Contract_sum = 38000, Status = "Signed" },
                new Contract { Id = 2, NaturalPersonId = 2, LegalPersonId = 0, Date = DateTime.ParseExact("2023-04-05", "yyyy-MM-dd", null), Contract_sum = 48000, Status = "Signed" },
                new Contract { Id = 3, NaturalPersonId = 3, LegalPersonId = 0, Date = DateTime.ParseExact("2023-03-30", "yyyy-MM-dd", null), Contract_sum = 28000, Status = "Signed" },
                new Contract { Id = 4, NaturalPersonId = 4, LegalPersonId = 0, Date = DateTime.ParseExact("2023-02-28", "yyyy-MM-dd", null), Contract_sum = 18000, Status = "Signed" },
                new Contract { Id = 5, NaturalPersonId = 0, LegalPersonId = 1, Date = DateTime.ParseExact("2023-01-10", "yyyy-MM-dd", null), Contract_sum = 58000, Status = "Signed" },
                new Contract { Id = 6, NaturalPersonId = 0, LegalPersonId = 2, Date = DateTime.ParseExact("2022-04-10", "yyyy-MM-dd", null), Contract_sum = 28000, Status = "Signed" },
                new Contract { Id = 7, NaturalPersonId = 0, LegalPersonId = 3, Date = DateTime.ParseExact("2022-04-10", "yyyy-MM-dd", null), Contract_sum = 38000, Status = "Signed" },
                new Contract { Id = 8, NaturalPersonId = 0, LegalPersonId = 4, Date = DateTime.ParseExact("2022-04-10", "yyyy-MM-dd", null), Contract_sum = 68000, Status = "Signed" }


            );
            // использование Fluent API
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<NaturalPerson> NaturalPersons { get; set; }
        public DbSet<LegalPerson> LegalPersons { get; set; }
        public DbSet<Contract> Contracts { get; set; }
    }
}
