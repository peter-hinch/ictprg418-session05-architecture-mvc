using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session05ArchitectureMVC.Models
{
    public class Post
    {
        public long Id { get; set; }
        public string title { get; set; }
        public string newsContent { get; set; }
        public DateTime publishedOn { get; set; }
        public string publishedBy { get; set; }
    }
}
