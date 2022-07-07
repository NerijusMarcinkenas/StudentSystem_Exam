using StudentSystem_BusinessLogic.Interfaces;
using StudentSystem_Repository.Entities;
using StudentSystem_Repository.Interfaces;
using StudentSystem_Repository.Repositories;

namespace StudentSystem_BusinessLogic.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _dbRepository;

        public DepartmentService()
        {
            _dbRepository = new DbRepository();
        }

        public bool AddLecture(Lecture lecture)
        {
            var isAdded = _dbRepository.AddLectureToDb(lecture);
            if (isAdded)
            {
                _dbRepository.SaveChanges();
            }
            return isAdded;
        }
        public bool AddDepartment(Department department)
        {
            var exist = _dbRepository.IsDepartmentExist(department.Name);
            if (!exist)
            {
                _dbRepository.AddUpdateDepartment(department);
                _dbRepository.SaveChanges();
            }
            return exist;
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
                _dbRepository.AddUpdateDepartment(department);
                _dbRepository.SaveChanges();
            }
            return isAdded;

        }
        public void RemoveDepartmentLecture(Department department, Lecture lecture)
        {
            _dbRepository.RemoveDepartmentLecture(department, lecture);
            
            _dbRepository.SaveChanges();
        }
        public List<Lecture> GetDepartmentLectures(Department department) => _dbRepository.RetrieveLectures(department);
        public List<Lecture> GetLectures() => _dbRepository.RetrieveLectures();
        public Department GetDepartment(Guid id) => _dbRepository.RetrieveDepartament(id);
        public List<Department> GetDepartments() => _dbRepository.RetrieveDepartments();

    }
}
