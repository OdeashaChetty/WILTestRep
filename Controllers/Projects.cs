using Microsoft.AspNetCore.Mvc;

namespace WIL_Project.Controllers
{
    public class Projects : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
