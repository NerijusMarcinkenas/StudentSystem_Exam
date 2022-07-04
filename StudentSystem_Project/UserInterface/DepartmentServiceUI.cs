using StudentSystem_BusinessLogic.Services;
using StudentSystem_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem_Project.UserInterface
{
    public class DepartmentServiceUI
    {
        private DepartmentService _departmentService;

        public DepartmentServiceUI()
        {
            _departmentService = new DepartmentService();
        }

        public void ManageDepartment(int selection)
        {
            switch (selection)
            {
                case 1:
                    CreateDepartment();
                    break;
                case 2:
                    RemoveDepartment();
                    break;
                case 3:
                    AssignLecturesToDepartment();
                    break;
                case 4:
                    RemoveLecturesFromDepartment();
                    break;
                case 5:
                    ShowStudents();
                    break;
                case 6:
                    ShowLectures();
                    break;
                default:
                    break;
            }
        }
        public void CreateLecture()
        {
            Console.Write("Enter lecture name: ");
            var name = Console.ReadLine();
            var lecture = new Lecture(name);
            _departmentService.AddLecture(lecture);
        }
        private void CreateDepartment()
        {
            Console.WriteLine("Enter department name");
            var name = Console.ReadLine();
            var department = new Department(name);
            _departmentService.AddDepartment(department);
        }
        private void RemoveDepartment()
        {
            Console.WriteLine("Select department to remove");
            var dbDepartments = _departmentService.GetDepartments();
            Common.ShowItems(dbDepartments);
            var index = Common.IntParse();
            var department = Common.TryGet(dbDepartments, index);
            if (department is not null)
            {
                _departmentService.RemoveDepartment(department);
                Console.WriteLine("Department was removed successfully");
                return;
            }
            Console.WriteLine("Department was not found");
        }
        private void AssignLecturesToDepartment()
        {
            var department = GetDepartment();
            if (department is not null)
            {
                do
                {
                    Console.WriteLine("Please select lecture to assign:");
                    var lecture = GetLecture();

                    if (lecture is not null)
                    {
                        var isAdded = _departmentService.AddLectureToDepartment(department, lecture);
                        if (isAdded)
                        {
                            Console.WriteLine("Lecture is added successfully");

                        }
                        else
                        {
                            Console.WriteLine($"Lecture already exists in {department.Name}");
                        }
                    }
                    Console.WriteLine("Press enter to continue, any key to go back");

                } while (Console.ReadKey().Key == ConsoleKey.Enter);

            }
            else
            {
                Console.WriteLine("Department not found");
            }



        }
        private void RemoveLecturesFromDepartment()
        {
            var department = GetDepartment();
            if (department is not null)
            {
                do
                {
                    Console.WriteLine("Please select lecture to remove:");
                    var lecture = GetLecture();

                    if (lecture is not null)
                    {
                       _departmentService.RemoveDepartmentLecture(department, lecture);                       
                        Console.WriteLine("Lecture is added successfully");                       
                    }
                    Console.WriteLine("Press enter to continue, any key to go back");

                } while (Console.ReadKey().Key == ConsoleKey.Enter);
            }
            else
            {
                Console.WriteLine("Department not found");
            }
        }
        private void ShowStudents()
        {
            var department = GetDepartment();
            foreach (var student in department.Students)
            {
                Console.WriteLine(student);
            }
        }
        private void ShowLectures()
        {
            var department = GetDepartment();
            if (department is not null)
            {
                Console.WriteLine($"{department.Name} lectures:");
                foreach (var lecture in department.Lectures)
                {                    
                    Console.WriteLine(lecture) ;
                }
            }
            
        }

        private Department GetDepartment()
        {
            var dbDepartments = _departmentService.GetDepartments();
            Console.WriteLine("Please select department");
            Common.ShowItems(dbDepartments);
            var s = Common.IntParse();
            var department = Common.TryGet(dbDepartments, s);

            return _departmentService.GetDepartment(department.Id);
        }        
        private Lecture GetLecture()
        {
            var dbLectures = _departmentService.GetLectures();
            Common.ShowItems(dbLectures);
            int s = Common.IntParse();
            return Common.TryGet(dbLectures, s);

        }

    }
}
