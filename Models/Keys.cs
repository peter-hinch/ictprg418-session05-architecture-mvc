using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session05ArchitectureMVC.Models
{
    public class Keys
    {
        public string publicKey { get; set; }

        // For existing projects, use these following settings
        public string description { get; set; }
        public long? amount { get; set; }
        public string currency { get; set; }
    }
}
