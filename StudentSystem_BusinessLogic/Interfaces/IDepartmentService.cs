using StudentSystem_Repository.Entities;

namespace StudentSystem_BusinessLogic.Interfaces
{
    public interface IDepartmentService : IService
    {
        bool AddDepartment(Department department);
        bool AddLecture(Lecture lecture);
        bool AddLectureToDepartment(Department department, Lecture lecture);       
        List<Department> GetDepartments();
        bool RemoveDepartment(Department department);
        void RemoveDepartmentLecture(Department department, Lecture lecture);
    }
}