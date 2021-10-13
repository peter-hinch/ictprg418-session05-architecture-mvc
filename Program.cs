using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog.Extensions.Logging;
using NLog;

// Creating a global namespace to contain global variables.
namespace global
{
    public static class gLogger
    {
        // using NLog
        public static Logger log = null;
    }
}

namespace Session05ArchitectureMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging((hostingContext, logging) =>
                // Add configuration for NLog
                // 1. Requires NLog.Config and NLog.Web.AspNetCore packages to be added.
                // 2. Requires changes to be made to NLog.config
                {
                    //logging.AddNLog(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddDebug();
                    logging.AddNLog();

                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
