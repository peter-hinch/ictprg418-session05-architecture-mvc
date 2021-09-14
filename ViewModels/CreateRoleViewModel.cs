﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Session05ArchitectureMVC.ViewModels
{
    public class CreateRoleViewModel
    {
        [Display(Name = "Role Name")]
        [Required(ErrorMessage = "Please enter a role name.")]
        public string roleName { get; set; }
    }
}
