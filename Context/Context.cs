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
    internal class Context : DbContext
    {
        DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConfigurationManager.AppSettings.Get("PgSqlConnectionString"));
        }
    }
}
