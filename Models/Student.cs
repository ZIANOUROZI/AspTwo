using System.ComponentModel.DataAnnotations;

namespace AspTwo.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public virtual ICollection<Enrollment>? Enrollments { get; set; }
    }
}
