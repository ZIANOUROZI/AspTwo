using Microsoft.AspNetCore.Mvc;

namespace AspTwo.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
