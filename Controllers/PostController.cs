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
            // Display all the Post objects.
            /*
            p = _db.post.ToList<Post>();

            return View(p);
            */

            // Alternatively, the query can be made using LINQ.
            //var p1 = from v in _db.post select v;

            // LINQ can also be used to modify entries as they are retrieved:
            var p1 = from v1 in _db.post
                     join v2 in _db.department
                     on v1.Id equals v2.postId
                     select new
                     {
                         Id1 = v1.Id,
                         newsContent1 = v1.title + " (" + v2.deptName + ")",
                         publishedOn1 = v1.publishedOn,
                         publishedBy1 = v1.publishedBy
                     };

            List<Post> p3 = new List<Post>();
            foreach(var p2 in p1)
            {
                p3.Add(new Post
                    {
                        Id = p2.Id1,
                        newsContent = p2.newsContent1,
                        publishedOn = p2.publishedOn1,
                        publishedBy = p2.publishedBy1
                    }
                ); ;
            }

            return View(p3.ToList<Post>());
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
            // Find the corresponding post entry in the database.
            //Post p = _db.post.Find(Id);

            // Return the view with the post information.
            //return View(p);

            // Alternatively, the same can be achieved with LINQ.
            var p1 = from v in _db.post where v.Id == Id select v;

            // Return the first result.
            return View(p1.FirstOrDefault<Post>());
        }

        [HttpPost]
        public IActionResult Edit(Post p)
        {
            // Ensure fields are valid.
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Inform Entity Framework that the data for this entry has been modified.
            _db.Entry(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction("Display");
        }

        [HttpGet]
        public IActionResult Delete(long Id)
        {
            // Find the post by Id, then remove the post and save changes.
            Post p = _db.post.Find(Id);
            _db.post.Remove(p);

            _db.SaveChanges();

            return RedirectToAction("Display");
        }
    }
}
