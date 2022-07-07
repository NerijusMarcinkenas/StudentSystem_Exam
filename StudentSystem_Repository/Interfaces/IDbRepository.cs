using StudentSystem_Repository.Entities;

namespace StudentSystem_Repository.Interfaces
{
    public interface IDbRepository
    {       
        public List<Lecture> RetrieveLectures();
        public List<Lecture> RetrieveLectures(Department department);
        public Department RetrieveDepartament(Guid id);      
        public void SaveChanges();
    }
}
