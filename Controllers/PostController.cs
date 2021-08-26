using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Session05ArchitectureMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session05ArchitectureMVC.Controllers
{
    public class PostController : Controller
    {
        List<Post> p;
        private readonly TableDataContext _db;

        public PostController(TableDataContext db)
        {
            _db = db;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [Route("p")] // this allows the URL to be shortened to simply ./p
        public IActionResult ShowPost(int id)
        {
            return new ContentResult { Content = "My post controller (ShowPost method), post ID: " + id };
        }

        [Route("{year}/{month}/{key}")] // you can specify multiple arguments in the route
        public IActionResult ShowDate(int year, int month, string key)
        {
            return new ContentResult { Content = "Year: " + year + ", Month: " + month + ", Key: " + key };
        }

        public IActionResult Display()
        {
            p = _db.post.ToList<Post>();
            
            return View(p);
        }
        
        // Adding a keyword to assign an action method to a specific HTTP request
        [HttpGet]
        public IActionResult Add()
        {
            // Create a new Post object with the current timestamp prefilled.
            Post p = new Post { publishedOn = DateTime.Now };

            return View(p);
        }

        [HttpPost]
        public IActionResult Add(Post p2)
        {
            // Ensure fields are valid before posting.
            if(!ModelState.IsValid)
            {
                return View();
            }
            
            // Add the new post to the post table and save changes.
            _db.post.Add(p2);
            _db.SaveChanges();

            return RedirectToAction("Display");
        }

        [HttpGet]
        public IActionResult Edit(long Id)
        {
            Post p = _db.post.Find(Id);
            
            return View(p);
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
