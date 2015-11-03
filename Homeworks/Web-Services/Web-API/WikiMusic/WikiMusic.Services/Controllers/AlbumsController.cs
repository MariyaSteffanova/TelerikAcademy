namespace WikiMusic.Services.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models;
    using WebGrease.Css.Extensions;
    using WikiMusic.Models;

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/albums")]
    public class AlbumsController : ApiController
    {
        private IWikiMusicData data;

        public AlbumsController()
        {
            this.data = new WikiMusicData();
        }

        public IHttpActionResult Get()
        {
            var albums = this.data.Albums.All().ToList();
            return this.Ok(albums);
        }

        public IHttpActionResult GetById(int id)
        {
            return this.Ok(this.data.Albums.SearchFor(x => x.ID == id).First());
        }

        public IHttpActionResult Post([FromBody] IEnumerable<AlbumRequestModel> albums)
        {
            albums
                 
                 .ForEach(album =>
                 {
                     var newAlbum = new Album
                     {
                         Title = album.Title,
                         Year = album.Year,
                         Producer = album.Producer,
                         Artists = album.Artists.AsQueryable().ProjectTo<Artist>().ToList(),
                         ImgLink = album.ImgLink
                     };
                    

                     this.data.Albums.Add(newAlbum);
                 });
            
            this.data.SaveChanges();
            return this.Ok();
        }

        public IHttpActionResult Put(UpdateAlbumSongs data)
        {
            this.data.Albums.SearchFor(x => x.ID == data.Id)
                .ForEach(a =>
                {
                    data.Songs.AsQueryable().ProjectTo<Song>().ForEach(s => a.Songs.Add(s));
                });
            this.data.SaveChanges();
            return this.Ok();
        }

        public IHttpActionResult Put(int id, [FromBody] AlbumRequestModel updates)
        {
            var album = this.data.Albums.SearchFor(x => x.ID == id).First();

            updates
                .GetType()
                .GetProperties()
                .Where(x => x.GetValue(updates) != null)
                // .Select(p => p.GetValue(updates))
                .ToList()
                 .ForEach(pr =>
                 {
                     album.GetType().GetProperty(pr.Name).SetValue(album, pr.GetValue(updates));
                 });
            this.data.Albums.Update(album);
            this.data.SaveChanges();

            return this.Ok();
        }

        public IHttpActionResult Delete([FromBody] int id)
        {
            var album = this.data.Albums.SearchFor(x => x.ID == id).FirstOrDefault();
            this.data.Albums.Delete(album);

            this.data.SaveChanges();

            return this.Ok();
        }
    }
}