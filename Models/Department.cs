using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Session05ArchitectureMVC.Models
{
    public class Department
    {
        // Add [keywords] using System.ComponentModel.DataAnnotations
        // Validation can also be applied using decorator keywords
        [Key]
        public long deptId { get; set; }

        [Display(Name = "Department")]
        [Required(ErrorMessage = "Department is a required field")]
        public string deptName { get; set; }

        public long postId { get; set; }
    }
}
