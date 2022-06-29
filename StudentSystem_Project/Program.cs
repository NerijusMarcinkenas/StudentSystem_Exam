using StudentSystem_BusinessLogic;

namespace StudentSystem_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new StudentService();
            service.PopulateDb();
        }
    }
}

