using Microsoft.EntityFrameworkCore;
using StudentPlusDemoProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPlusDemoProject.Contexts
{
    internal class StudentContext : DbContext
    {
        public StudentContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Absenteeism> Absenteeism { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<ContactInfo> Contacts { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<PersonInfo> PersonInfos { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                //.UseLazyLoadingProxies()
                .UseNpgsql("Server = localhost; Port = 5432; Database = StudentPlusDb; User Id = postgres; Password = 123;"); //ConfigurationManager.AppSettings.Get("PgSqlConnectionString")
        }
    }
}
