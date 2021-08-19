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
        // Exercise: Override the default route to make Post controller the top level URL.
        //[Route("")]
        public IActionResult Index()
        {
            //return new ContentResult { Content = "My post controller (Index method)" };

            return View();
        }

        // Exercise: Add another action method ShowPost in the post controller.
        // Exercise: Show the post ID.
        [Route("p")] // this allows the URL to be shortened to simply ./p
        public IActionResult ShowPost(int id)
        {
            return new ContentResult { Content = "My post controller (ShowPost method), post ID: " + id };
        }

        // Exercise: Define an action method which will accept multiple parameters.
        [Route("{year}/{month}/{key}")] // you can specify multiple arguments in the route
        public IActionResult ShowDate(int year, int month, string key)
        {
            return new ContentResult { Content = "Year: " + year + ", Month: " + month + ", Key: " + key };
        }

        // Exercise: Create a view called Display which gives a page: "I am in display page."
        public IActionResult Display()
        {
            return View();
        }

        // Exercise: Create a view called Add which gives a page: "I am in add page."
        public IActionResult Add()
        {
            return View();
        }

        // Exercise: Create a view called Edit which gives a page: "I am in edit page."
        public IActionResult Edit()
        {
            return View();
        }

        // Exercise: Create a view called Delete which gives a page: "I am in delete page."
        public IActionResult Delete()
        {
            return View();
        }
    }
}
