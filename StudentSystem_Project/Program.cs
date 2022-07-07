using StudentSystem_BusinessLogic;
using StudentSystem_Project.Interfaces;
using StudentSystem_Project.UserInterface;

namespace StudentSystem_Project
{
    class Program
    {
        static void Main(string[] args)
        {            
            IMainUI userInterface = new MainUI();
            userInterface.OpenMenu();
        }
    }
}

