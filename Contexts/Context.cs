using Microsoft.EntityFrameworkCore;
using StudentPlusDemoProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPlusDemoProject.Context
{
    internal class StudentContext : DbContext
    {
        public StudentContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();

        }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server = localhost; Port = 5432; Database = StudentPlusDb; User Id = postgres; Password = 123;"); //ConfigurationManager.AppSettings.Get("PgSqlConnectionString")
        }
    }
}
