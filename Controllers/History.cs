using Microsoft.AspNetCore.Mvc;

namespace WILTestDesignSpace.Controllers
{
    public class History : Controller
    {
        public IActionResult DonationHistory()
        {
            return View();
        }
    }
}
