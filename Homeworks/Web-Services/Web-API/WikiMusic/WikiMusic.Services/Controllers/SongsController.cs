namespace WikiMusic.Services.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using Data;
    using WebGrease.Css.Extensions;
    using WikiMusic.Models;

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/songs")]
    public class SongsController : ApiController
    {
        private IWikiMusicData data;

        public SongsController()
        {
            this.data = new WikiMusicData();
        }

        public IEnumerable<Song> Get()
        {
            var songs = this.data.Songs.All().ToList();
            return songs;
        }

        public IHttpActionResult Post([FromBody] IEnumerable<SongRequestModel> songs)
        {
            if (songs == null)
            {
                return this.BadRequest();
            }

            songs.ForEach(song =>
            {
                this.data.Songs.Add(new Song
                {
                    Title = song.Title,
                    Year = song.Year,
                    Genre = song.Genre
                });
            });
            
            this.data.SaveChanges();
            this.data.Dispose();
            return this.Ok("Song added");
        }

        public IHttpActionResult Put([FromBody]IEnumerable<SongRequestModel> songs)
        {
            var name = songs.First().Title;

            var dbSong = this.data.Songs
                .SearchFor(x => x.Title == name)
                .FirstOrDefault();

            if (dbSong == null)
            {
                return this.NotFound();
            }

            if (name == null || songs.Count() != 2)
            {
                return this.BadRequest();
            }

            var updates = songs.ElementAt(1);
            dbSong.Title = updates.Title ?? dbSong.Title;
            dbSong.Year = updates.Year == 0 ? dbSong.Year : updates.Year;
            dbSong.Genre = updates.Genre ?? dbSong.Genre;

            this.data.Songs.Update(dbSong);
            this.data.SaveChanges();
            return this.Ok("song updated!");
        }

        public IHttpActionResult Delete([FromBody] SongRequestModel song)
        {
            var dbSong = this.data.Songs
                .SearchFor(x => x.Title == song.Title)
                .FirstOrDefault();

            if (dbSong == null)
            {
                return this.NotFound();
            }

            this.data.Songs.Delete(dbSong);
            this.data.SaveChanges();

            return this.Ok("Song deleted");
        }
    }
}