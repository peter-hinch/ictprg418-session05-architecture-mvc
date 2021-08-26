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

        public PostController()
        {
            p = new List<Post>
            {
                new Post{Id=1, title="News Article", newsContent="Here is a wonderful news article.", publishedBy="Jose Chacko", publishedOn=Convert.ToDateTime("2019-01-01")},
                new Post{Id=2, title="Another Article", newsContent="This is another informative news article.", publishedBy="Priya Jose", publishedOn=Convert.ToDateTime("2019-02-02")},
                new Post{Id=3, title="A Third Article", newsContent="Wouldn't you know it? Here's another article, with the same high quality writing as the other two.", publishedBy="Hanna Jose", publishedOn=Convert.ToDateTime("2019-03-03")},
            };
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

            this.p.Add(p2);

            return View("Display", p);
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
