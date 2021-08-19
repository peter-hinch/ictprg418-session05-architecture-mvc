using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session05ArchitectureMVC.Controllers
{
    public class PostController : Controller
    {
        // Exercise: Create a new controller called Post, with an action method Index.
        public IActionResult Index()
        {
            return new ContentResult { Content = "My post controller (Index method)" };
        }
    }
}
