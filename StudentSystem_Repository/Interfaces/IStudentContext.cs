using Microsoft.EntityFrameworkCore;
using StudentSystem_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem_Repository.Interfaces
{
    public interface IStudentContext
    {
        public DbSet<Department> Departments { get; }
        public DbSet<Lecture> Lectures { get; }
        public DbSet<Student> Students { get; }
    }
}
