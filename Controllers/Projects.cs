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
            // Fetch data directly in the controller method
            var npos = (from org in _context.Organisations
                        join proj in _context.Projects
                        on org.OrganisationRegNo equals proj.OrganisationRegNo
                        where proj.Active == true // Assuming you only want active projects
                        select new NPO
                        {
                            OrganisationName = org.DirectorFullName, // Assuming Organisation Name is Director's FullName
                            Motivation = proj.ProjectDescription,
                            AmountRequested = proj.Amount
                        }).ToList();

            return View(npos);
        }
    }
}
