using AspTwo.Data;
using AspTwo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspTwo.Controllers
{
    public class TeacherStudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TeacherStudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        //Hämta alla lärare som undervisar i programmering1
        public IActionResult Index()
        {
            var teachers = _context.Teachers
                .Where(t => t.Courses.Any(c => c.CourseName == "Programmering1")).ToList();
               

           if(teachers != null)
            {
                return View(teachers);
            }
           else
            {
                return View("Not found");
            }
        }

        //Hämta alla elever och deras lärare, skriver ut både elevernas namn och namnet på alla lärare de har
        public IActionResult All()
        {
            var teacherStudent = _context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Courses)
                .ThenInclude(c => c.Teachers).Select(s => new AllViewModel
                {
                    studentName = s.StudentName,
                    teachers = s.Enrollments.Select(e => e.Courses.Teachers).ToHashSet()
                }).ToList();
                
            return View(teacherStudent);
        }
        public IActionResult AllStudentAndTeacher()
        {
            var studentTeacherProgrammerin1 = _context.Teachers
                .Include(c => c.Courses)
                .ThenInclude(e => e.Enrollments)
                .ThenInclude(s => s.Students)
                .Where(t => t.Courses.Any(c => c.CourseName == "Programmering1")).ToList();
            return View(studentTeacherProgrammerin1);
        }
		public IActionResult AllStudentAndCourses()
		{
            var studentProgrammerin1 = _context.Courses
                .Where(c => c.CourseName == "Programmering1")
                .SelectMany(c => c.Enrollments)
                .Select(e => e.Students)
                .Distinct()
                .ToList();
			return View(studentProgrammerin1);
		}
	}
}
