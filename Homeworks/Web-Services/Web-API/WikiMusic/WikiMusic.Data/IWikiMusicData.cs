namespace WikiMusic.Data
{
    using Models;

    public interface IWikiMusicData
    {
        IGenericRepository<Album> Albums { get; }

        IGenericRepository<Artist> Artists { get; }

        IGenericRepository<Song> Songs { get; }

        void SaveChanges();

        void Dispose();
    }
}