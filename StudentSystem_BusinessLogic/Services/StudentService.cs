using StudentSystem_Repository.Entities;
using StudentSystem_Repository.Repositories;

namespace StudentSystem_BusinessLogic.Services
{
    public class StudentService // to do implement IStudentService
    {
        private DbRepository _dbRepository; // To do Use IDbRepository

        public StudentService()
        {
            _dbRepository = new DbRepository();
        }
        public void AddStudent(Student student)
        {
            var isAdedd = _dbRepository.AddUpdateStudent(student);
            if (isAdedd)
            {
                _dbRepository.SaveChanges();
                Console.WriteLine("Student is added!");
            }
            else
            {
                Console.WriteLine("Student already exists");
            }

        }
        public void AddDepartment(Department department)
        {           
            if (_dbRepository.IsDepartmentExist(department.Name))
            {
                Console.WriteLine("Department already exists");
            }
            else
            {
                AddUpdateDepartment(department);
            }         
        }
        public void AddLecture(Lecture lecture)
        {           
            var isAdded = _dbRepository.AddLecture(lecture);
            if (isAdded)
            {
                _dbRepository.SaveChanges();
                return;
            }
            Console.WriteLine("Lecture already exists");
           
        }
        public bool AssignStudentToDepartment(Student student, string departmentName)
        {
            var dbDepartment = GetDepartment(departmentName);
            if (dbDepartment is not null)
            {
                _dbRepository.AssignStudentToDepartment(student, dbDepartment);
                _dbRepository.SaveChanges();
                return true;
            }
            else
            {
                Console.WriteLine("Department not found!");
                return false;
            }

        }
        public void AddStudentToDepartment(Department department, Student student)
        {
            _dbRepository.AddStudentToDepartment(department, student);
            AddUpdateDepartment(department);
        }
        public bool AddLectureToDepartment(Department department, Lecture lecture)
        {
            var isAdded = _dbRepository.AddLectureToDepartment(department, lecture);
            if (isAdded)
            {
                AddUpdateDepartment(department);
                return true;           
            }
            else
            {
               return false;
            }
        }      
        public List<Lecture> GetLectures() => _dbRepository.RetrieveLectures();
        public List<Lecture> GetLectures(Department department) => _dbRepository.RetrieveLectures(department);
        public Student GetStudent(ulong personalCode) => _dbRepository.RetrieveStudent(personalCode);
        public Department GetDepartment(string name) => _dbRepository.RetrieveDepartament(name);
        public List<Department> GetDepartments() => _dbRepository.RetrieveDepartments();
        private void AddUpdateDepartment(Department department)
        {                 
            _dbRepository.AddUpdateDepartment(department);
            _dbRepository.SaveChanges();
        }
    }
}
