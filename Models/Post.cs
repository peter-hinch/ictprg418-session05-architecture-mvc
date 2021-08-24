using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session05ArchitectureMVC.Models
{
    public class hobbies
    {
        public string hName { get; set;  }
        public bool bHobby { get; set; }
    }
    
    public class Post
    {
        public long Id { get; set; }
        public string title { get; set; }
        public string newsContent { get; set; }
        public DateTime publishedOn { get; set; }
        public string publishedBy { get; set; }
        // Remove later
        public List<SelectListItem> listP = new List<SelectListItem>();
        public string gender { get; set; }
        public List<hobbies> hobbies { get; set; }
    }
}
