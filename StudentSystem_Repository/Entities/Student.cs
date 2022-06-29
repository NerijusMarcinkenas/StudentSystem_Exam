using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentSystem_Repository.Entities
{
    public class Student
    {
        public Guid Id { get; set; }

        [ForeignKey("Department")]
        public Guid DepartmentId { get; set; }

        [Required]
        [Column(TypeName = ("nvarchar(50)"))]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = ("nvarchar(50)"))]
        public string LastName { get; set; }
        public List<Lecture> Lectures { get; set; }
        public Department Department { get; set; }
        public Student(){}
        public Student(string name, string lastName)
        {
            Name = name;
            Name = lastName;
            Lectures = new List<Lecture>();            
        }
    }
}
