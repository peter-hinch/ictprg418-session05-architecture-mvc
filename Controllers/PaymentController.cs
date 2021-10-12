using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Session05ArchitectureMVC.Models;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session05ArchitectureMVC.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly Keys keys;

        public PaymentController(IConfiguration configuration)
        {
            this.configuration = configuration;
            string pubKey = configuration["Stripe:PublishableKey"];
            keys = new Keys {
                amount = 500,
                currency = "aud",
                description = "Sample",
                publicKey = pubKey
            };
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(keys);
        }

        // This is the action method that the form in the Payment/Index view
        // posts to.
        [AllowAnonymous]
        public IActionResult Charge(string stripeEmail, string stripeToken)
        {
            // Workaround because key is not persisting from Startup.cs
            string secretKey = configuration.GetValue<string>("Stripe:SecretKey");
            StripeConfiguration.ApiKey = secretKey;

            var customers = new CustomerService();
            var charges = new ChargeService();

            // Pass email and token to CustomerService.Create() .
            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = keys.amount,
                Description = keys.description,
                Currency = keys.currency,
                CustomerId = customer.Id
            });

            return View();
        }

        [AllowAnonymous]
        public IActionResult Error()
        {
            return View();
        }
    }
}
