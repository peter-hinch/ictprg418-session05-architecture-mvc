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

        // Exercise: Add another action method ShowPost in the post controller.
        // Exercise: Show the post ID.
        [Route("p")] // this allows the URL to be shortened to simply ./p
        public IActionResult ShowPost(int id)
        {
            return new ContentResult { Content = "My post controller (ShowPost method), post ID: " + id };
        }
    }
}
