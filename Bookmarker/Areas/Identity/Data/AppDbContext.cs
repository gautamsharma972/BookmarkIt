using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookmarker.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bookmarker.Models
{
    public class AppDbContext : IdentityDbContext<BookmarkerUsers>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        //public DbSet<BookmarkerUsers> Users { get; set; }

            public DbSet<Category> Categories { get; set; }
        public DbSet<Bookmarks> Bookmarks { get; set; }
    }
}
