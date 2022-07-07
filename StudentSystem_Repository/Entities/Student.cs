using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace StudentSystem_Repository.Entities
{ 
    public class Student
    {
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]       
        public string PersonalCode { get; set; }

        [ForeignKey("Department")]
        public Guid? DepartmentId { get; set; }

        [Required]
        [Column(TypeName = ("nvarchar(50)"))]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = ("nvarchar(50)"))]
        public string LastName { get; set; }
        public List<Lecture> Lectures { get; set; }
        public Department Department { get; set; } 
        public Student(){}
        
        public Student(string name, string lastName, string personalCode)
        {
            Name = name;
            LastName = lastName;
            PersonalCode = personalCode;                    
            Lectures = new List<Lecture>();            
        }

        public override string ToString()
        {
            if (Department is null)
            {
                return $"{Name} {LastName} personal code - ({PersonalCode}) is not assigned to department";
            }
            return $"{Name} {LastName} personal code - ({PersonalCode}) from {Department.Name} department";
        }
    }
}
