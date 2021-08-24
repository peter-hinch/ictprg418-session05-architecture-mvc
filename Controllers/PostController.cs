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
            // Add some information to the ViewBag, this is page based.
            //ViewBag.title = "Something";
            //ViewBag.content = "Here's some stuff";
            //ViewBag.publishedOn = "2021-08-19";
            //ViewBag.publishedBy = "Peter";

            string strNews = null;
            
            strNews += "(CNN)Fires are raging at a record rate in Brazil's Amazon rainforest, and scientists warn that it could strike a devastating blow to the fight against climate change.";

            strNews += "The fires are burning at the highest rate since the country's space research center, the National Institute for Space Research (known by the abbreviation INPE), began tracking them in 2013, the center said Tuesday.";


            strNews += "There have been 72,843 fires in Brazil this year, with more than half in the Amazon region, INPE said. That's more than an 80% increase compared with the same period last year.";

            strNews += "The Amazon is often referred to as the planet's lungs, producing 20% of the oxygen in the Earth's atmosphere.";

            strNews += "It is considered vital in slowing global warming, and it is home to uncountable species of fauna and flora. Roughly half the size of the United States, it is the largest rainforest on the planet.";

            Post p = new Post
            {
                Id = 1,
                title = "Amazon News",
                newsContent = strNews,
                publishedBy = "Sophia Mark",
                publishedOn = Convert.ToDateTime("2019-02-03"),
            };

            return View(p);
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
