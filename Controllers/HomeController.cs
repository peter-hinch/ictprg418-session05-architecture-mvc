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
            ContentResult c = new ContentResult();
            c.Content = "My home controller";
            
            // Can return:
            // ContentResult, FileContentResult, FilePathResult, FileStreamResult,
            // EmptyResult, JavaScriptResult, JsonResult, RedirectToResult,
            // HttpUnauthorisedResult, RedirectToRouteResult, ViewResult.
            // All of which which are extensions of the IActionResult class.
            return c;
        }
    }
}
