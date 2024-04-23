using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspTwo.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        [ForeignKey("Teachers")]
        public int FkTeacherId { get; set; }
        //Navigering for teacher
        public Teacher? Teachers { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
