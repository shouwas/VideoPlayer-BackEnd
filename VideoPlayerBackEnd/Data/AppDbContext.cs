using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VideoPlayerBackEnd.Models;

namespace VideoPlayerBackEnd.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=VideoPlayerDb")
        {

        }
        public DbSet<Video> Videos { get; set; }
    }
}