using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session05ArchitectureMVC.ViewModels
{
    public class ManageRoleViewModel
    {
        public string userId { get; set; }
        public string roleId { get; set; }

        public List<SelectListItem> userList { get; set; }
        public List<SelectListItem> roleList { get; set; }
    }
}
