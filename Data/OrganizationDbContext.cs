using CRUDOperations.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDOperations.Data
{
    public class OrganizationDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        //public DbSet<EmpDetailForSp> EmpDetailsForSp { get; set; }

        //public DbSet<EmpDetail> EmpDetails { get; set; }

        //public DbSet<Student> Students { get; set; }
        //public DbSet<Course> Courses { get; set; }
        //public DbSet<StudentCourse> StudentCourses { get; set; }

        //public DbSet<Project> Projects { get; set; }
        //public DbSet<Module> Modules { get; set; }
        //public DbSet<Task> Tasks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=OrgEFDb_CRUD;Trusted_Connection=True;TrustServerCertificate=True;");
            //optionsBuilder.UseLazyLoadingProxies();

        }

    }
}

