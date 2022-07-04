using StudentSystem_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem_BusinessLogic.Interfaces
{
    public interface IService
    {
        public Department GetDepartment(Guid id);    
        public List<Lecture> GetLectures();
        public List<Lecture> GetLectures(Department department);
    }
}
