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
                    CreateStudent();
                    break;
                case 2:
                    RemoveStudent();
                    break;
                case 3:                   
                    AssignLecturesToStudent();
                    break;
                case 4:                     
                    RemoveStudentLectures();
                    break;
                case 5:
                    AssignStudentToDepartment();
                    break;
                case 6:
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
            var department = GetDepartment();
           
            var depName = Console.ReadLine();
            var student = new Student(name, lastName, personalCode);
            var isAssigned = _studentService.AssignStudentToDepartment(student, department.Id);
            if (isAssigned)
            {
                Console.WriteLine($"Student assigned to {depName} successfully");
            }

        }
        private void RemoveStudent()
        {
            var student = GetStudentByPersonalCode();
            if (student is not null)
            {
                if (_studentService.RemoveStudent(student))
                {
                    Console.WriteLine("Student was removed");
                    return;
                }
                Console.WriteLine($"Student {student.Name} with personal code -({student.PersonalCode}) was not found");
                return;
            }
            Console.WriteLine("Student not found");


        }
        private void AssignLecturesToStudent()
        {
            var student = GetStudentByPersonalCode();
            var dbLectures = _studentService.GetLectures(student.Department);
            int j = 1;
            int index;
            do
            {
                Console.WriteLine("Please select lecture to assign, or [0] to go back:");
                Common.ShowItems(dbLectures);
                index = Common.IntParse();
                var lecture = Common.TryGet(dbLectures, index);
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
                }

            } while (index != -1);
            _studentService.AddUpdateStudent(student);
            
        }
        private void RemoveStudentLectures()
        {
            var student = GetStudentByPersonalCode();
            var studentLectures = student.Lectures;
            int j = 1;
            int index;
            do
            {
                Console.WriteLine("Please select lecture to assign, or [0] to go back:");
                Common.ShowItems(studentLectures);
                index = Common.IntParse();
                var lecture = Common.TryGet(studentLectures, index);
                if (lecture is null)
                {
                    Console.WriteLine("Lecture doesn't exist");
                }
                else
                {
                    student.Lectures.Remove(lecture);
                }

            } while (index != -1);
            _studentService.AddUpdateStudent(student);

        }
        private void AssignStudentToDepartment()
        {
            if (Disclaimer())
            {
                return;
            }          

            var student = GetStudentByPersonalCode();
            var department = GetDepartment();
            var isAssigned = _studentService.AssignStudentToDepartment(student, department.Id);
            if (isAssigned)
            {
                Console.WriteLine($"Student assigned successfully to {department.Name}");
            }
        }
        private Department GetDepartment()
        {
            var dbDepartments = _studentService.GetDepartments();
            Console.WriteLine("Please select department");
            Common.ShowItems(dbDepartments);
            var s = Common.IntParse();
            var department = Common.TryGet(dbDepartments, s);

            return _studentService.GetDepartment(department.Id);
        }
        private Student GetStudent()
        {
            var dbStudents = _studentService.GetStudents();
            Console.WriteLine("Please select student");
            Common.ShowItems(dbStudents);
            var s = Common.IntParse();
            var student = Common.TryGet(dbStudents, s);
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
                    Console.WriteLine($"{lecture}\n");
                }
            }
           
        }
        private bool Disclaimer()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Disclaimer! Changing student department, will couse all student's lectures to be assigned to a department lectures by default");
            Console.ResetColor();
            Console.WriteLine("Press escape to cancel");
            return Console.ReadKey().Key == ConsoleKey.Escape;
        }
        
    }   
}
