using Microsoft.AspNetCore.Mvc;

namespace WILTestDesignSpace.Controllers
{
    public class Organisation : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Approved()
        {
            return View();
        }
        public IActionResult Rejected()
        {
            return View();
        }
    }
}
