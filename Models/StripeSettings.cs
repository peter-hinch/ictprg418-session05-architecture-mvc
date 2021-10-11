using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session05ArchitectureMVC.Models
{
    public class StripeSettings
    {
        public string secretKey { get; set; }
        public string publishableKey { get; set; }
    }
}
