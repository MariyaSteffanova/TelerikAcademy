namespace WikiMusic.Data
{
    using System.Configuration;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Lib;
    using Models;
    using Configuration = Migrations.Configuration;

    public class WikiMusicDbContext : DbContext, IWikiMusicDbContext
    {
        public WikiMusicDbContext()
        {
            var setter = new ConnectionStringsSetter("WikiMusicDb", true);
            Database.Connection.ConnectionString = setter.ConnectionString;
         
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<WikiMusicDbContext, Configuration>());

            // Code block for changing already existing connection string in the app.config file
            // setter.SetConnectionString();
            // ConfigurationManager.RefreshSection("connectionStrings");
            // Database.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["WikiMusicConnection"].ToString();
        }

        public virtual IDbSet<Album> Albums { get; set; }

        public virtual IDbSet<Artist> Artists { get; set; }

        public virtual IDbSet<Song> Songs { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new void Dispose()
        {
            base.Dispose();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
