using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentSystem_Repository.Entities
{
    public class Lecture
    {
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = ("nvarchar(150)"))]
        public string Name { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Student> Students { get; set; }



        public Lecture(){}
        public Lecture(string name)
        {
            Name = name;
            Departments = new List<Department>();
            Students = new List<Student>();
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
