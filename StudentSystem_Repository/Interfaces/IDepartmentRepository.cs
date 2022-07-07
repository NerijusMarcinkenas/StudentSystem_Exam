using StudentSystem_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem_Repository.Interfaces
{
    public interface IDepartmentRepository : IDbRepository
    {
        public void AddUpdateDepartment(Department department);
        public bool RemoveDepartment(Department department);
        public bool AddLectureToDepartment(Department department, Lecture lecture);
        public void RemoveDepartmentLecture(Department department, Lecture lecture);
        public bool AddLectureToDb(Lecture lecture);
        public bool IsDepartmentExist(string name);       
        public List<Department> RetrieveDepartments();
    }
}
