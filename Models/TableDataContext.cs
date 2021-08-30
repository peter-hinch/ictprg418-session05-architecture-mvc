using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session05ArchitectureMVC.Models
{
    // Class needs to implement IdentityDbContext.
    public class TableDataContext : IdentityDbContext
    {
        // Field must have the same name as the table name.
        public DbSet<Post> post { get; set; }

        // Use : base(options) will pass the options through to the base class.
        public TableDataContext(DbContextOptions<TableDataContext> options) : base(options)
        {
            // Ensure that the database has been created.
            Database.EnsureCreated();
        }
    }
}
