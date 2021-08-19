using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session05ArchitectureMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Can return:
            // ContentResult, FileContentResult, FilePathResult, FileStreamResult,
            // EmptyResult, JavaScriptResult, JsonResult, RedirectToResult,
            // HttpUnauthorisedResult, RedirectToRouteResult, ViewResult.
            // All of which which are extensions of the IActionResult class.

            //ContentResult c = new ContentResult();
            //c.Content = "My home controller";
            //return c;

            // Alternatively:
            return new ContentResult { Content = "My home controller (Index method)" };
        }

        // Exercise: Add a Post action method
        // This action method is accessible at the URL ./Home/Post
        // Exercise: Return "Hello, you passed ID: 2"
        // This attribute is accessible at the URL ./Home/Post/2
        public IActionResult Post(int id)
        {
            return new ContentResult { Content = "My home controller (Post method). Hello, you passed ID: " + id };
        }

        // Exercise: Accept a boolean in a new action method
        // This attribute is accessible at the URL ./Home/PostBool/true
        public IActionResult PostBool(bool id) 
        {
            return new ContentResult { Content = "The boolean result is: " + id };
        }
    }
}
