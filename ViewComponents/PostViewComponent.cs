using Microsoft.AspNetCore.Mvc;
using Session05ArchitectureMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session05ArchitectureMVC.ViewComponents
{
    // Implement ViewComponent (using Microsoft.AspNetCore.Mvc)
    public class PostViewComponent : ViewComponent
    {
        private readonly IPostRepository _postRepo;

        public PostViewComponent(IPostRepository postRepo)
        {
            _postRepo = postRepo;
        }

        // Important.
        public IViewComponentResult Invoke()
        {
            var result = _postRepo.listPost();
            return View(result);

            // Activity: Try to call a comoponent with non default name.

            // Solution: A name other than the default can be given by passing
            // a string as the first argument. In the example below, the
            // Example.cshtml is in the same folder as where Default.cshtml
            // would have been.
            //return View("Example", result);
        }
    }
}
