namespace VideoPlayerBackEnd.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using VideoPlayerBackEnd.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<VideoPlayerBackEnd.Data.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VideoPlayerBackEnd.Data.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Videos.Add(new Video() { Title = "Angular", Url= "Link", Descreption= "Blabla"});
        }
    }
}
