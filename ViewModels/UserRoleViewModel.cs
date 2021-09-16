using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session05ArchitectureMVC.ViewModels
{
    public class UserRoleViewModel
    {
        public string roleID { get; set; }

        public string roleName { get; set; }

        public bool isSelected { get; set; }
    }

    public class User1
    {
        public string userName { get; set; }
        public List<UserRoleViewModel> list = new List<UserRoleViewModel>();
    }
}
