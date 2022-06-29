using StudentSystem_Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem_BusinessLogic
{
    public class StudentService
    {

        // IDbRepository = new DbRepository();
        public void PopulateDb()
        {
            var dbRepository = new DbRepository();
            dbRepository.PopulateDepartment();
        }
    }
}
