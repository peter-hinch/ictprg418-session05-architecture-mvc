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
            string strNews = null;
            
            strNews += "(CNN)Fires are raging at a record rate in Brazil's Amazon rainforest, and scientists warn that it could strike a devastating blow to the fight against climate change.";

            strNews += "The fires are burning at the highest rate since the country's space research center, the National Institute for Space Research (known by the abbreviation INPE), began tracking them in 2013, the center said Tuesday.";


            strNews += "There have been 72,843 fires in Brazil this year, with more than half in the Amazon region, INPE said. That's more than an 80% increase compared with the same period last year.";

            strNews += "The Amazon is often referred to as the planet's lungs, producing 20% of the oxygen in the Earth's atmosphere.";

            strNews += "It is considered vital in slowing global warming, and it is home to uncountable species of fauna and flora. Roughly half the size of the United States, it is the largest rainforest on the planet.";

            p = new List<Post>
            {
                new Post{Id=1, title="Amazon News", newsContent=strNews, publishedBy="Jose Chacko", publishedOn=Convert.ToDateTime("2019-01-01")},
                new Post{Id=2, title="Another Article", newsContent=strNews, publishedBy="Priya Jose", publishedOn=Convert.ToDateTime("2019-02-02")},
                new Post{Id=3, title="A Third Article", newsContent=strNews, publishedBy="Hanna Jose", publishedOn=Convert.ToDateTime("2019-03-03")},
            };

            return View(p);
        }
        
        // Adding a keyword to assign an action method to a specific HTTP request
        [HttpGet]
        public IActionResult Add()
        {
            Post p = new Post { publishedOn = DateTime.Now };

            return View(p);
        }

        [HttpPost]
        public IActionResult Add(Post p)
        {
            return View();
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
