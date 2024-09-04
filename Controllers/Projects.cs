using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WILTestDesignSpace.Models;

namespace WIL_Project.Controllers
{
    public class Projects : Controller
    {
        private readonly BumbleBeesContext _context;

        public Projects(BumbleBeesContext context)
        {
            _context = context;
        }

        public IActionResult ViewProjects()
        {
            return View();
        }
    }
}
