using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Session05ArchitectureMVC.ViewModels;
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
        
        public AdministrationController(UserManager<IdentityUser> _userManager,
            RoleManager<IdentityRole> _roleManager)
        {
            // Pass in the user and role managers.
            userManager = _userManager;
            roleManager = _roleManager;
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View(new CreateRoleViewModel());
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
