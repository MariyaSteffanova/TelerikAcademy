namespace WikiMusic.Services
{
    using Models;
    using WikiMusic.Models;

    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            ConfigureSongs();
            ConfigureAlbums();
            ConfigureArtist();
        }

        private static void ConfigureSongs()
        {
            AutoMapper.Mapper.CreateMap<Song, SongRequestModel>();
            AutoMapper.Mapper.CreateMap<SongRequestModel, Song>();
        }

        private static void ConfigureAlbums()
        {
            AutoMapper.Mapper.CreateMap<Album, AlbumRequestModel>();
            AutoMapper.Mapper.CreateMap<AlbumRequestModel, Album>();
        }

        private static void ConfigureArtist()
        {
            AutoMapper.Mapper.CreateMap<Artist, ArtistRequestModel>();
            AutoMapper.Mapper.CreateMap<ArtistRequestModel, Artist>();
        }
    }
}