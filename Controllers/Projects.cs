using Microsoft.AspNetCore.Mvc;

namespace WIL_Project.Controllers
{
    public class Projects : Controller
    {
        public IActionResult ViewProjects()
        {
            return View();
        }
    }
}
