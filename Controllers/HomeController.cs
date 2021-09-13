using Microsoft.AspNetCore.Http;
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
            string myString = HttpContext.Session.GetString("userID"); // string myString = Session["userID"].ToString();

            // A method with return type IActionResult can return any of the following:
            // ContentResult, FileContentResult, FilePathResult, FileStreamResult,
            // EmptyResult, JavaScriptResult, JsonResult, RedirectToResult,
            // HttpUnauthorisedResult, RedirectToRouteResult, ViewResult.
            // All of these are extensions of the IActionResult class.

            // ContentResult can be used to return content.
            //ContentResult c = new ContentResult();
            //c.Content = "My home controller";
            //return c;

            // Alternatively:
            //return new ContentResult { Content = "My home controller (Index method)" };

            // ViewResult can be used to direct to the corresponding Razor view.
            // This will look for the view in the location: Views/Home/Index.cshtml
            //ViewResult v = View(); 
            //return v;

            // Aternatively:
            return View();
        }

        // Exercise: Add a Post action method
        // This action method is accessible at the URL ./Home/Post
        public IActionResult Post()
        {
            //return new ContentResult { Content = "My home controller (Post method). Hello, you passed ID: " + id };

            return View();
        }

        // Exercise: Return "Hello, you passed ID: 2"
        // This attribute is accessible at the URL ./Home/PostInt/2
        public IActionResult PostInt(int id)
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
