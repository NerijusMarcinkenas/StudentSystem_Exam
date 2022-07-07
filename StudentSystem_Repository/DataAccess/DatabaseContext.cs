using Microsoft.EntityFrameworkCore;
using StudentSystem_Repository.Entities;
using StudentSystem_Repository.Interfaces;

namespace StudentSystem_Repository.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Student> Students { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = N-LENOVO\SQLEXPRESS; Initial Catalog = StudentsDB; Integrated Security = True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasIndex(i => i.PersonalCode).IsUnique();
            modelBuilder.Entity<Student>().Property(i => i.Id).HasDefaultValueSql("newid()");
            modelBuilder.Entity<Lecture>().Property(i => i.Id).HasDefaultValueSql("newid()");
            modelBuilder.Entity<Department>().Property(i => i.Id).HasDefaultValueSql("newid()");           
        }
    }
}
