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
            var isAdedd = _dbRepository.AddUpdateStudent(student);
            _dbRepository.SaveChanges();
            return isAdedd;
          

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
        public bool AssignStudentToDepartment(Student student, Guid id)
        {
            var dbDepartment = GetDepartment(id);
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
        public List<Lecture> GetLectures(Department department) => _dbRepository.RetrieveLectures(department);
       
    }
}
