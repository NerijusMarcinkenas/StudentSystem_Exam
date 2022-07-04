using StudentSystem_BusinessLogic.Services;
using StudentSystem_Repository.Entities;

namespace StudentSystem_Project.UserInterface
{
    public class UserInterface
    {
        private readonly DepartmentServiceUI _departmentServiceUI;
        private readonly StudentServiceUI _studentServiceUI;
     
  
        public UserInterface()
        {
            _departmentServiceUI = new DepartmentServiceUI();
            _studentServiceUI = new StudentServiceUI();
        }
        public void OpenMenu()
        {
            var selected = MainMenu();
            switch (selected)
            {
                case 1:
                     var sSelection = StudentManagerMenu();
                    _studentServiceUI.ManageStudent(sSelection);
                    break;
                case 2:
                    var dSelection = DepartmentManagerMenu();
                    _departmentServiceUI.ManageDepartment(dSelection);
                    break;
                case 3:
                    _departmentServiceUI.CreateLecture();
                    break;
                default:
                    break;
            }
        }
        private static int MainMenu()
        {
            Console.WriteLine("Welcome. Please select:");
            Console.WriteLine("" +
                "[1] - Manage students\n" +
                "[2] - Manage departments\n" +
                "[3] - Create lectures");
            return Common.IntParse();
        }
        private static int StudentManagerMenu()
        {
            Console.WriteLine("" +
                "[1] - Add new student\n" +
                "[2] - Remove student\n" +
                "[3] - Assign student lectures\n" +
                "[4] - Remove student lectures\n" +
                "[5] - Assign student to department\n" +
                "[6] - Show student lectures");
           return Common.IntParse();
        }              
        private static int DepartmentManagerMenu()
        {
            Console.WriteLine("" +
                "[1] - Create department\n" +
                "[2] - Delete department\n" +
                "[3] - Assign lecture to department\n" +
                "[4] - Remove lecture from department\n" +
                "[5] - Show students\n" +
                "[6] - Show lectures");
            return Common.IntParse();
        }

    }
}
