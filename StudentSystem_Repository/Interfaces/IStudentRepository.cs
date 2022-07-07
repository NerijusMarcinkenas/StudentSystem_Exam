using StudentSystem_Repository.Entities;

namespace StudentSystem_Repository.Interfaces
{
    public interface IStudentRepository : IDbRepository
    {
        public bool AddUpdateStudent(Student student);
        public bool RemoveStudent(Student student);
        public void AssignStudentToDepartment(Student student, Department department);
        public List<Department> RetrieveDepartments();
        public List<Student> RetrieveStudents();
        public Student RetrieveStudent(string studentCode);
        bool IsStudentExist(string personalCode);
    }
}
