using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session05ArchitectureMVC.Controllers
{
    public class AdministrationController : Controller
    {
        // Requires using Microsoft.AspNetCore.Identity.
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
