using System.ComponentModel.DataAnnotations;

namespace AspTwo.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public virtual ICollection<Course>? Courses { get; set; }
    }
}
