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
        // Validation can also be applied using decorator keywords
        [Key]
        [Range(1,1000, ErrorMessage = "ID should be between 1 and 1000")]
        [Required(ErrorMessage = "ID is a required field")]
        public long Id { get; set; }

        [Display(Name ="Subject")]
        [Required(ErrorMessage = "Name is a required field")]
        public string title { get; set; }

        [Display(Name = "Content")]
        [Required(ErrorMessage = "Please enter some content for this post")]
        [MinLength(5, ErrorMessage = "Please enter a post at least 5 characters long")]
        [DataType(DataType.MultilineText)]
        public string newsContent { get; set; }

        [Display(Name = "Published On")]
        [DataType(DataType.DateTime)]
        public DateTime publishedOn { get; set; }

        [Display(Name = "Author")]
        [Required(ErrorMessage = "Author is a required field")]
        [StringLength(20, MinimumLength = 2, 
            ErrorMessage = "Author field requires between 2 and 20 characters")]
        public string publishedBy { get; set; }
    }
}
