using Microsoft.EntityFrameworkCore;
using StudentSystem_Repository.DataAccess;
using StudentSystem_Repository.Entities;
using StudentSystem_Repository.Interfaces;

namespace StudentSystem_Repository.Repositories
{    
    public class DbRepository //To do Implement IDbRepository
    {
        private readonly StudentContext _context;

        public DbRepository()
        {
            _context = new StudentContext();
        }

        public void AddUpdateDepartment(Department department)
        {
            if (_context.Departments.Any( i => i.Id == department.Id))
            {
                _context.Departments.Update(department);
            }
            else
            {
                _context.Departments.Add(department);
            }
           
        }       
        public bool AddUpdateStudent(Student student)
        {
            if (!_context.Students.Any( n => n.PersonalCode == student.PersonalCode))
            {
                _context.Students.Add(student);                
                return true;
            }
            else
            {
                _context.Update(student);
            }
            return false;
        }
        public void AssignStudentToDepartment(Student student, Department department)
        {    
            var dbStudent = _context.Students
                .Include( d => d.Department)
                .Include(l => l.Lectures)
                .SingleOrDefault( c => c.PersonalCode == student.PersonalCode);

            if (dbStudent is not null)
            {
                dbStudent.Department = department;
                _context.Students.Update(dbStudent);
            }
            else
            {
                student.Department = department;
                _context.Students.Add(student);
            }            
           
        }      
        public bool AddStudentToDepartment(Department department, Student student)
        {
            var dbDepartment = _context.Departments.Include(s => s.Students).SingleOrDefault(i => i.Id == department.Id);
            if (dbDepartment.Students.Any( c => c.PersonalCode == student.PersonalCode))
            {
                return false;
            }
            dbDepartment.Students.Add(student);
            _context.Departments.Update(dbDepartment);
            return true;
        }        
        public bool AddLectureToDepartment(Department department, Lecture lecture)
        {
           var dbDepartament =  _context.Departments.Include(l => l.Lectures).SingleOrDefault(d => d.Id == department.Id);
            if (dbDepartament.Lectures.Any( n => n.Name == lecture.Name))
            {               
                return false;
            }
           dbDepartament.Lectures.Add(lecture);
            _context.Departments.Update(dbDepartament);
            return true;
        }
        public bool AddLecture(Lecture lecture)
        {
            if (_context.Lectures.Any(l => l.Name.ToUpper() == lecture.Name.ToUpper()))
            {
                return false;
            }            
            _context.Lectures.Add(lecture);
            return true;
        }
        public List<Lecture> RetrieveLectures()
        {
           return _context.Lectures.ToList();
        }
        public List<Lecture> RetrieveLectures(Department department)
        {
            return _context.Departments.Include(l => l.Lectures).SingleOrDefault(i => i.Id == department.Id).Lectures.ToList();
        }
        public Department RetrieveDepartament(string name)
        {
           return _context.Departments
                .Include(l => l.Lectures)
                .Include( s => s.Students)
                .SingleOrDefault( n => n.Name.ToUpper() == name.ToUpper() );
        }
        public List<Department> RetrieveDepartments()
        {
            return _context.Departments.ToList();
        }
        public Student RetrieveStudent(ulong studentCode)
        {
            return _context.Students.Include( l => l.Lectures).SingleOrDefault(c => c.PersonalCode == studentCode);
        }
        public bool IsDepartmentExist(string name) => _context.Departments.Any(n => n.Name.ToUpper() == name.ToUpper());
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
