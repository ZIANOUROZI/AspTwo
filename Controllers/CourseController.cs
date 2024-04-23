using Microsoft.AspNetCore.Mvc;

namespace AspTwo.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
