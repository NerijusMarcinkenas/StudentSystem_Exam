using StudentSystem_BusinessLogic.Interfaces;
using StudentSystem_Repository.Entities;
using StudentSystem_Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem_BusinessLogic.Services
{
    public class DepartmentService : IService
    {
        private readonly DbRepository _dbRepository;

        public DepartmentService()
        {
            _dbRepository = new DbRepository();
        }

        public bool AddLecture(Lecture lecture)
        {
            var isAdded = _dbRepository.AddLecture(lecture);
            if (isAdded)
            {
                _dbRepository.SaveChanges();               
            }          
            return isAdded;
        }
        public bool AddDepartment(Department department)
        {
            var isAdded = _dbRepository.IsDepartmentExist(department.Name);
            if (isAdded)
            {
                AddUpdateDepartment(department);
            }
            return isAdded;
        }
        public bool RemoveDepartment(Department department)
        {
            var isRemoved = _dbRepository.RemoveDepartment(department);
            _dbRepository.SaveChanges();
            return isRemoved;

        }
        public bool AddLectureToDepartment(Department department, Lecture lecture)
        {
            var isAdded = _dbRepository.AddLectureToDepartment(department, lecture);
            if (isAdded)
            {
                AddUpdateDepartment(department);                
            }
            return isAdded;
          
        }
        public void RemoveDepartmentLecture(Department department, Lecture lecture)
        {
            _dbRepository.RemoveDepartmentLecture(department, lecture);
            _dbRepository.SaveChanges();
        }
        public List<Lecture> GetLectures(Department department) => _dbRepository.RetrieveLectures(department);
        public List<Lecture> GetLectures() => _dbRepository.RetrieveLectures();
        public Department GetDepartment(Guid id) => _dbRepository.RetrieveDepartament(id);
        public List<Department> GetDepartments() => _dbRepository.RetrieveDepartments();

        private void AddUpdateDepartment(Department department)
        {
            _dbRepository.AddUpdateDepartment(department);
            _dbRepository.SaveChanges();
        }
        
    }
}
