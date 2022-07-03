using StudentSystem_BusinessLogic.Services;
using StudentSystem_Repository.Entities;

namespace StudentSystem_Project.UserInterface
{
    public class UserInterface
    {
        private StudentService _service;

        public UserInterface()
        {
            _service = new StudentService();
        }


        public void OpenMenu()
        {            
            Menu();
            MainMenu();
        }

        private void Menu()
        {
            Console.WriteLine("Welcome. Please select:");
            Console.WriteLine("" +
                "[1] - Manage student\n" +
                "[2] - Create lecture\n" +
                "[3] - Create department\n" +
                "[4] - Manage department lectures\n" +
                "[5] - Manage student lectures ");

        }

        private void MainMenu()
        {

            int selection = Common.IntParse();
            switch (selection)
            {
                case 1:
                    CreateStudent();
                    break;
                case 2:
                    CreateLecture();
                    break;
                case 3:
                    CreateDepartment();
                    break;
                case 4:
                    
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
            Console.Write("Enter Personal Code: ");
            var input = Console.ReadLine();
            var personalCode = Common.PersonalCodeParse(input);
            Console.Write("Enter department name to assign student to: ");
            var depName = Console.ReadLine();
            var student = new Student(name, lastName, personalCode);            
            var isAssigned = _service.AssignStudentToDepartment(student, depName);
            if (isAssigned)
            {
                Console.WriteLine($"Student assigned to {depName} successfuly");
            }
        }
        private void CreateLecture()
        {
            Console.Write("Enter lecture name");
            var name = Console.ReadLine();
            var lecture = new Lecture(name);
            _service.AddLecture(lecture);
        }
        private void CreateDepartment()
        {
            Console.WriteLine("Enter department name");
            var name = Console.ReadLine();
            var department = new Department(name);
            _service.AddDepartment(department);
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
                        var isAdded = _service.AddLectureToDepartment(department, lecture);
                        if (isAdded)
                        {
                            Console.WriteLine("Lecture is added successfuly");

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
        private void AssignLecturesToStudent(Student student)
        {
            var dbLectures = _service.GetLectures(student.Department);
            int j = 1;
            int s;
            do
            {
                Console.WriteLine("Please select lecture to assign, or [0] to go back:");
                Common.ShowItems(dbLectures);
                s = Common.IntParse() - 1;
                var lecture = dbLectures[s];
                if (student.Lectures.Any(n => n.Name == lecture.Name))
                {
                    Console.WriteLine("Lecture already added");
                }
                else
                {
                    student.Lectures.Add(lecture);
                }

            } while (s != 0);



        }
        private Department GetDepartment()
        {
            var dbDepartments = _service.GetDepartments();
            Console.WriteLine("Please select department");
            Common.ShowItems(dbDepartments);
            var s = Common.IntParse();
            return _service.GetDepartment(dbDepartments[s].Name);
        }
        private Lecture GetLecture()
        {
            var dbLectures = _service.GetLectures();            
            Common.ShowItems(dbLectures);
            int s = Common.IntParse() - 1;           
            return dbLectures[s];
            
        }
        




    }
}
