using StudentSystem_Repository.DataAccess;
using StudentSystem_Repository.Entities;
using StudentSystem_Repository.Interfaces;

namespace StudentSystem_Repository.Repositories
{    
    public class DbRepository : IDbRepository
    {
        private StudentContext _context;

        public DbRepository()
        {
            _context = new StudentContext();

        }

        public void PopulateDepartment()
        {
            var department = new Department("Informatics");            
            var lectures = new List<Lecture>()
            {
                new Lecture("Artificial Intelligence"),
                new Lecture("Informatics Engineering"),
                new Lecture("Information Systems"),
                new Lecture("Informatics"),
                new Lecture("Software Systems")
            };

            department.Lectures = lectures;

            
            _context.Add(department);
            _context.SaveChanges();
        }
    }
}
