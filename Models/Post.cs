using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Session05ArchitectureMVC.Models
{
    public class Post
    {
        // Add [keywords] using System.ComponentModel.DataAnnotations
        [Key]
        public long Id { get; set; }

        [Display(Name ="Subject")]
        public string title { get; set; }

        [Display(Name = "Content")]
        [DataType(DataType.MultilineText)]
        public string newsContent { get; set; }

        [Display(Name = "Published On")]
        [DataType(DataType.DateTime)]
        public DateTime publishedOn { get; set; }

        [Display(Name = "Author")]
        public string publishedBy { get; set; }
    }
}
