namespace WikiMusic.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WikiMusic.Data.WikiMusicDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "WikiMusic.Data.WikiMusicDbContext";
        }

        protected override void Seed(WikiMusic.Data.WikiMusicDbContext context)
        {
            context.Artists.AddOrUpdate(
                a => a.Name,
                new Artist
                {
                    Name = "Dubioza kolektiv",
                    Country = "Bosna",
                    BirthDate = new DateTime(2000, 1, 1),
                    ImgLink = "http://e-volutionradio.com/wp-content/uploads/2015/06/dubioza-kolektiv-515a21052f5f7.jpg"
                });
        }
    }
}
