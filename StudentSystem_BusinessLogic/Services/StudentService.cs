using StudentSystem_BusinessLogic.Interfaces;
using StudentSystem_Repository.Entities;
using StudentSystem_Repository.Interfaces;
using StudentSystem_Repository.Repositories;

namespace StudentSystem_BusinessLogic.Services
{
    public class StudentService : IStudentService
    {
        private IStudentRepository _dbRepository;

        public StudentService()
        {
            _dbRepository = new DbRepository();
        }
        public bool AddUpdateStudent(Student student)
        {
            var isAddedUpdatet = _dbRepository.AddUpdateStudent(student);
            _dbRepository.SaveChanges();            
            return isAddedUpdatet;
        }
        public bool CreateStudent(string name, string lastName, string personalCode)
        {
            var student = new Student(name, lastName, personalCode);
            if (_dbRepository.IsStudentExist(personalCode))
            {
                return false;
            }
            AddUpdateStudent(student);
            return true;
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
        public Student GetStudent(string personalCode) => _dbRepository.RetrieveStudent(personalCode);
        public List<Student> GetStudents() => _dbRepository.RetrieveStudents();
        public List<Lecture> GetLectures() => _dbRepository.RetrieveLectures();       
        public List<Lecture> GetDepartmentLectures(Department department) => _dbRepository.RetrieveLectures(department);

    }
}
