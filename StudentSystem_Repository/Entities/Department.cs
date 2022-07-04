using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StudentSystem_Repository.Entities
{
    public class Department
    {
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = ("nvarchar(50)"))] 
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public List<Lecture> Lectures { get; set; }
        public Department() { }
        public Department(string name)
        {
            Name = name;
            Students = new List<Student>();
            Lectures = new List<Lecture>();
        }
        public override string ToString()
        {
            return $"{Name} ";
        }
    }
}
