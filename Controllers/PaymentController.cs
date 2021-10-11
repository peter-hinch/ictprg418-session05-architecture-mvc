using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session05ArchitectureMVC.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IConfigurationRoot configuration;

        public IActionResult Index()
        {
            return View();
        }
    }
}
