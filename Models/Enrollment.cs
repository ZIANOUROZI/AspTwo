using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspTwo.Models
{
    public enum Grade
    {
        A,
        B,
        C,
        D,
        E,
        F
    }
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }
        public Grade Grades { get; set; }

        [ForeignKey("Students")]
        public int FkStudentId { get; set; }
        public Student? Students { get; set; }

        [ForeignKey("Courses")]
        public int FkCourseId { get; set; }
        public Course? Courses { get; set; }

    }
}
