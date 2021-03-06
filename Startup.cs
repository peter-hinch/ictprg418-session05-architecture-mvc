using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using Session05ArchitectureMVC.Models;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session05ArchitectureMVC
{
    public class Startup
    {
        // This file is the entry point of our project.

        // Declare a configuration variable. Readonly means it can only be
        // modified in the constructor.
        private readonly IConfigurationRoot configuration;

        // Create a constructor for configuration information.
        public Startup(IWebHostEnvironment env)
        {
            configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                // We can get the content root from the env object.
                .AddJsonFile(env.ContentRootPath + "/config.json")
                .Build();
            // Obtain the global logging object.
            global.gLogger.log = LogManager.GetCurrentClassLogger();
        }

        // This method gets called by the runtime. Use this method to add services
        // to the container. For more information on how to configure your
        // application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // 1. Register MVC design pattern
            // 2. Set the authorization policy in options (anon. function is an
            //    optional parameter).
            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });

            // Entity Framework requires the following dependencies to be installed:
            // - Microsoft.EntityFrameworkCore 
            // - Microsoft.AspNetCore.Identity.EntityFrameworkCore
            // - Microsoft.EntityFrameworkCore.SqlServer

            // Add the database context.
            services.AddDbContext<TableDataContext>(options =>
            {
                // Retrieve the connection string from the config.json file.
                var connectionString = configuration.GetConnectionString("PostConnection");
                // using Microsoft.EntityFrameworkCore;
                // Add the SQL server to the options object.
                options.UseSqlServer(connectionString);
            });

            // Add database migration service.
            // Requires installation of Microsoft.EntityFrameworkCore.Tools
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<TableDataContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IPostRepository, PostRepository>();

            // For session variables
            services.AddDistributedMemoryCache();
            services.AddSession();

            // Example to demonstrate the differences between singleton, scoped
            // and transient - Navigate to '~/Home/Add' and observe the post
            // count to test these.
            // Using Singleton - this will be the same for every controller and
            // every service.
            services.AddSingleton<IPostTestRepository, PostTestRepository>();
            // Using Scoped - this is will be the same within this request, but
            // differ accross different requests.
            //services.AddScoped<IPostTestRepository, PostTestRepository>();
            // Using Transient - this is always different, a new instance will
            // be created for every controller and every service.
            //services.AddTransient<IPostTestRepository, PostTestRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // These are the forms an NLog message can take for use in a
            // try / catch block.
            try
            {
                //throw new Exception();
            }
            catch (Exception ex)
            {
                // One parameter for string only, overload with two paramaters
                // allows passing the exception as well.
                //global.gLogger.log.Info(ex, "This is a debug message, here is the exception: " + ex.Message);
                global.gLogger.log.Debug(ex, "This is a debug message, here is the exception: " + ex.Message);
                //global.gLogger.log.Warn(ex, "This is a debug message, here is the exception: " + ex.Message);
                //global.gLogger.log.Error(ex, "This is a debug message, here is the exception: " + ex.Message);
                //global.gLogger.log.Fatal(ex, "This is a debug message, here is the exception: " + ex.Message);
            }
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Set up stripe using secret key from appsettings.json .
            string secretKey = configuration.GetValue<string>("Stripe:SecretKey");
            StripeConfiguration.ApiKey = secretKey;

            // For session variables
            app.UseSession();

            // Middleware
            app.UseRouting();

            // Authorization
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // Specifying 'Home' will look for the 'HomeController.cs'
                // controller and the 'Index()' method.
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Add}/{id?}");
            });

            // Added when using database migration.
            // NOTE: Order is important, place before UseFileServer().
            app.UseAuthentication();

            app.UseFileServer();
        }
    }
}
