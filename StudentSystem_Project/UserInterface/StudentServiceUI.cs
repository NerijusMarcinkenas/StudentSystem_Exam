using StudentSystem_BusinessLogic.Services;
using StudentSystem_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem_Project.UserInterface
{
    public class StudentServiceUI
    {
        private StudentService _studentService;

        public StudentServiceUI()
        {
            _studentService = new StudentService();
        }

        public void ManageStudent(int selection)
        {           
            switch (selection)
            {
                case 1:
                    Console.Clear();
                    CreateStudent();
                    break;
                case 2:
                    Console.Clear();
                    RemoveStudent();
                    break;
                case 3:
                    Console.Clear();
                    AssignLecturesToStudent();
                    break;
                case 4:
                    Console.Clear();
                    RemoveStudentLectures();
                    break;
                case 5:
                    Console.Clear();
                    AssignStudentToDepartment();
                    break;
                case 6:
                    Console.Clear();
                    ShowStudentLectures();
                    break;
                default:
                    break;
            }
        }
        private void CreateStudent()
        {
            Console.Write("Please enter name: ");
            var name = Console.ReadLine();
            Console.Write("Enter last name: ");
            var lastName = Console.ReadLine();            
            var personalCode = Common.PersonalCodeParse();          
           var successfull = _studentService.CreateStudent(name,lastName,personalCode);
            if (successfull)
            {
                Console.WriteLine("Student created successfully");
            }
            else
            {
                Console.WriteLine("Personal code already exist");
            }
            Common.PressAnyKey();
        }
        private void RemoveStudent()
        {
            var student = GetStudentByPersonalCode();
            if (student is not null)
            {
                if (_studentService.RemoveStudent(student))
                {
                    Console.WriteLine($"{student} was removed");
                    return;
                }
                Console.WriteLine($"Student {student.Name} with personal code -({student.PersonalCode}) was not found");
                return;
            }
            else
            {
                Console.WriteLine("Student not found");
            }           
            Common.PressAnyKey();
        }
        private void AssignLecturesToStudent()
        {
            var student = GetStudentByPersonalCode();
            if (student.Department is null)
            {
                Console.WriteLine("Student department is not assigned");
                return;
            }

            var dbLectures = _studentService.GetDepartmentLectures(student.Department);           
            int index;        

            do
            {
                Console.Clear();                
                Console.WriteLine("Please select lecture to assign:");

                Common.ShowItems(dbLectures);               
                index = Common.IntParse();                
                var lecture = Common.TryGetItem(dbLectures, index);
                if (lecture is null)
                {
                    Console.WriteLine("Lecture doesn't exist");                 
                }
                else if (student.Lectures.Any(n => n.Name == lecture.Name))
                {
                    Console.WriteLine("Lecture already assigned");
                }
                else
                {
                    student.Lectures.Add(lecture);
                    Console.WriteLine($"{lecture} assigned successfully");
                }
                Console.WriteLine("Press enter to continue, any key to go back");
            } while (Console.ReadKey().Key == ConsoleKey.Enter);
            _studentService.AddUpdateStudent(student);
        }    
        private void RemoveStudentLectures()
        {
            var student = GetStudentByPersonalCode();
           

            int index;
          
            if (student is null)
            {
                Console.WriteLine("Student not found");
                return;
            }
            else if (student.Department is null)
            {
                Console.WriteLine("Student department is not assigned");
                return;
            }
            do
            {
                Console.Clear();
                Console.WriteLine("Please select lecture to remove, or [0] to go back:");
                Common.ShowItems(student.Lectures);
                index = Common.IntParse();             
                var lecture = Common.TryGetItem(student.Lectures, index);
                if (lecture is null)
                {
                    Console.WriteLine("Lecture doesn't exist");
                }
                else
                {
                    student.Lectures.Remove(lecture);
                    Console.WriteLine($"{lecture} was removed succesfully");
                }
                Console.WriteLine("Press enter to continue, any key to go back");
            } while (Console.ReadKey().Key == ConsoleKey.Enter);
            _studentService.AddUpdateStudent(student);
        }       
       
        private void AssignStudentToDepartment()
        {
            if (Common.Disclaimer())
            {
                return;
            }          
            var student = GetStudentByPersonalCode();
            var department = GetDepartment();
            if (department is not null)
            {
                var isAssigned = _studentService.AssignStudentToDepartment(student, department.Id);
                if (isAssigned)
                {
                    Console.WriteLine($"Student was assigned successfully to {department.Name}");
                }
            }
            else
            {
                Console.WriteLine("Department not found");
            }
            Common.PressAnyKey();
        }
        private Department GetDepartment()
        {
            var dbDepartments = _studentService.GetDepartments();
            Console.WriteLine("Please select department");
            Common.ShowItems(dbDepartments);
            var s = Common.IntParse();
            var department = Common.TryGetItem(dbDepartments, s);
            if (department is not null)
            {
                return _studentService.GetDepartment(department.Id);
            }
            return null;
        }
        private Student GetStudent()
        {
            var dbStudents = _studentService.GetStudents();
            Console.WriteLine("Please select student");
            Common.ShowItems(dbStudents);
            var s = Common.IntParse();
            var student = Common.TryGetItem(dbStudents, s);
            if (student is null)
            {
                return null;
            }
            return _studentService.GetStudent(student.PersonalCode);

        }
        private Student GetStudentByPersonalCode()
        {            
            var code = Common.PersonalCodeParse();
            return  _studentService.GetStudent(code);
        }       
        private void ShowStudentLectures()
        {
            var student = GetStudent();
            if (student is not null)
            {
                foreach (var lecture in student.Lectures)
                {
                    Console.WriteLine($"{lecture}");
                }
            }
            else
            {
                Console.WriteLine("Student not found");
            }
            Common.PressAnyKey();

        }
        
        
    }   
}
