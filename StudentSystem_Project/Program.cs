using StudentSystem_BusinessLogic;
using StudentSystem_Project.UserInterface;

namespace StudentSystem_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var menu = new UserInterface.UserInterface();
                menu.OpenMenu();
            }
         

        }
    }
}

