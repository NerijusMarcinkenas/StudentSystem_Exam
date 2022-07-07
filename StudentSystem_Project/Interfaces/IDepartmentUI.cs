using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem_Project.Interfaces
{
    public interface IDepartmentUI
    {
        public void ManageDepartment(int selection);
        void CreateLecture();
    }
}
