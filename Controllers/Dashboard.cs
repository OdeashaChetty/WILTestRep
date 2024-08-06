using Microsoft.AspNetCore.Mvc;

namespace WIL_Project.Controllers
{
    public class Dashboard : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
