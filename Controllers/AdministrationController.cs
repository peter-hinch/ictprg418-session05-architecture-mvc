using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View(new CreateRoleViewModel());
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if( ModelState.IsValid )
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.roleName
                };

                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if( result.Succeeded )
                {
                    return View("Display", roleManager.Roles);
                }

                foreach( IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("key", error.Description);
                }
            }
            
            return View("Display", roleManager.Roles);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);
            IdentityResult result = await roleManager.DeleteAsync(role);

            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("key", error.Description);
            }

            return View("Display", roleManager.Roles);
        }

        [HttpGet]
        public IActionResult ManageRole()
        {
            ManageRoleViewModel mRole = new ManageRoleViewModel();
            FillArray(mRole);

            return View(mRole);
        }

        [HttpPost]
        public async Task<IActionResult> ManageRole(ManageRoleViewModel mRole)
        {
            // Find user and role.
            var role = await roleManager.FindByIdAsync(mRole.roleId);
            var user = await userManager.FindByIdAsync(mRole.userId);

            // If either is null, return an error.
            if( role == null || user == null)
            {
                return View("Not found");
            }

            // If this role to user association does not already exist, set the
            // new associtation.
            if( !(await userManager.IsInRoleAsync(user, role.Name)) )
            {
                var result = await userManager.AddToRoleAsync(user, role.Name);
            }
            
            return View("Display", roleManager.Roles);
        }

        // Private function to populate dropdown elements for ManageRole
        // action method.
        private void FillArray(
            ManageRoleViewModel mRole)
        {
            // Populate a dropdown with user information
            var users = userManager.Users;
            mRole.userList = new List<SelectListItem>();

            foreach( var user in users)
            {
                // Generate select list items and assign text and value to
                // each
                SelectListItem item = new SelectListItem();
                item.Text = user.UserName;
                item.Value = user.Id;
                mRole.userList.Add(item);
            }
            
            // Populate a dropdown with role information
            var roles = roleManager.Roles;
            mRole.roleList = new List<SelectListItem>();

            foreach( var role in roles)
            {
                // Generate select list items and assign text and value to
                // each
                SelectListItem item = new SelectListItem();
                item.Text = role.Name;
                item.Value = role.Id;
                mRole.roleList.Add(item);
            }
        }

        // An action method to display users and their associated roles.
        [HttpGet]
        public async Task<IActionResult> DisplayRole()
        {
            List<IdentityUser> listUser = new List<IdentityUser>();
            List<IdentityRole> listRole = new List<IdentityRole>();
            var users = userManager.Users;
            var roles = roleManager.Roles;
            foreach (var user in users) { listUser.Add(user); }
            foreach (var role in roles) { listRole.Add(role); }

            var model = new List<User1>();
            foreach (var user in listUser)
            {
                User1 user1 = new User1 { userName = user.UserName };
                foreach (var role in listRole)
                {
                    var UserRoleViewModel = new UserRoleViewModel
                    {
                        roleID = role.Id,
                        roleName = role.Name
                    };

                    if (await userManager.IsInRoleAsync(user, role.Name))
                    {
                        UserRoleViewModel.isSelected = true;
                    }
                    else
                    {
                        UserRoleViewModel.isSelected = false;
                    }
                    user1.list.Add(UserRoleViewModel);

                }
                model.Add(user1);
            }
            return View(model);
        }
    }
}
