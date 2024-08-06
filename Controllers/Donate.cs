using Microsoft.AspNetCore.Mvc;

namespace WIL_Project.Controllers
{
    public class Donate : Controller
    {
        public IActionResult DonatePage()
        {
            return View();
        }
    }
}
