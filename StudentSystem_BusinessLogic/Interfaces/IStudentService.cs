using StudentSystem_Repository.Entities;

namespace StudentSystem_BusinessLogic.Interfaces
{
    public interface IStudentService : IService
    {
        bool AddUpdateStudent(Student student);
        bool AssignStudentToDepartment(Student student, Guid departmentId);
        bool CreateStudent(string name, string lastName, ulong personalCode);
        List<Department> GetDepartments();
        Student GetStudent(ulong personalCode);
        List<Student> GetStudents();
        bool RemoveStudent(Student student);
    }
}