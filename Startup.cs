using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Session05ArchitectureMVC.Models;
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
                // We can get the content root from the env object
                .AddJsonFile(env.ContentRootPath + "/config.json")
                .Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Register MVC design pattern.
            services.AddMvc();

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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // For session variables
            app.UseSession();

            // Middleware
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // Specifying 'Home' will look for the 'HomeController.cs'
                // controller and the 'Index()' method.
                endpoints.MapControllerRoute("default", "{controller=Account}/{action=Register}/{id?}");
            });

            // Added when using database migration.
            // NOTE: Order is important, place before UseFileServer().
            app.UseAuthentication();

            app.UseFileServer();
        }
    }
}
