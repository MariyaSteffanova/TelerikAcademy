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
    }
}