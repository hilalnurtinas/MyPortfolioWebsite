using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using MyPortfolioWebsite.DAL.Entities;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace MyPortfolioWebsite.DAL.Context
{
    public class MyPortfolioContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; initial Catalog = MyPortfolioDb; " +
            "integrated Security = true; TrustServerCertificate=true;");
        }

        public DbSet<About> About { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Experience> Experience { get; set; }
        public DbSet<Feature> Feature { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Portfolio> Portfolio { get; set; }
        public DbSet<Reference> Reference { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<SocialMedia> SocialMedia { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<BlogPost> BlogPost { get; set; }
        public DbSet<Cv> Cv { get; set; }



    }
}