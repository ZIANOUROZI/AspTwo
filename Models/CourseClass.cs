using System.ComponentModel.DataAnnotations.Schema;

namespace AspTwo.Models
{
    public class CourseClass
    {
        public int CourseClassId { get; set; }
        public string Title { get; set; }
        [ForeignKey("Teachers")]
        public int FkTeacherId { get; set; }
        public Teacher? Teachers { get; set; }
    }
}
