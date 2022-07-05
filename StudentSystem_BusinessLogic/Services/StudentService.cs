using StudentSystem_BusinessLogic.Interfaces;
using StudentSystem_Repository.Entities;
using StudentSystem_Repository.Repositories;

namespace StudentSystem_BusinessLogic.Services
{
    public class StudentService : IService // to do implement IStudentService
    {
        private DbRepository _dbRepository; // To do Use IDbRepository

        public StudentService()
        {
            _dbRepository = new DbRepository();
        }
        public bool AddUpdateStudent(Student student)
        {
            var isAddedUpdate = _dbRepository.AddUpdateStudent(student);
            if (isAddedUpdate)
            {
                _dbRepository.SaveChanges();
            }          
           return isAddedUpdate;
        }             
        public bool CreateStudent(string name, string lastName, ulong personalCode)
        {
            var student = new Student(name, lastName, personalCode);
            return  AddUpdateStudent(student);             
        }
        public bool RemoveStudent(Student student)
        {
            if (_dbRepository.RemoveStudent(student))
            {
                _dbRepository.SaveChanges();               
                return true;
            }
            return false;
        }
        public bool AssignStudentToDepartment(Student student, Guid departmentId)
        {
            var dbDepartment = GetDepartment(departmentId);
            if (dbDepartment is not null)
            {
                _dbRepository.AssignStudentToDepartment(student, dbDepartment);
                _dbRepository.SaveChanges();
                return true;
            }
            return false;            
        }               
        public Department GetDepartment(Guid id) => _dbRepository.RetrieveDepartament(id);
        public List<Department> GetDepartments() => _dbRepository.RetrieveDepartments();
        public Student GetStudent(ulong personalCode) => _dbRepository.RetrieveStudent(personalCode);
        public List<Student> GetStudents() => _dbRepository.RetrieveStudents();
        public List<Lecture> GetLectures() => _dbRepository.RetrieveLectures();
        public List<Lecture> GetDepartmentLectures(Department department) => _dbRepository.RetrieveLectures(department);
       
    }
}
