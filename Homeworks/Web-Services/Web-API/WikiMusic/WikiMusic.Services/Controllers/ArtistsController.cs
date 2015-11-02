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
    [RoutePrefix("api/artists")]
    public class ArtistsController : ApiController
    {
        private IWikiMusicData data;

        public ArtistsController()
        {
            this.data = new WikiMusicData();
        }

        public IHttpActionResult Get()
        {
            var artists = this.data.Artists.All().ToList();
            return this.Ok(artists);
        }

        public IHttpActionResult GetById(int id)
        {
            return this.Ok(this.data.Artists.SearchFor(x => x.ID == id).First());
        }

        public IHttpActionResult Post([FromBody] ArtistRequestModel artist)
        {
            this.data.Artists.Add(new Artist
            {
                Name = artist.Name,
                Country = artist.Country,
                BirthDate = artist.BirthDate,
                ImgLink = artist.ImgLink
            });

            this.data.SaveChanges();
            return this.Ok();
        }

        public IHttpActionResult Put([FromBody] UpdateArtistByIdModel data)
        {
            data.Updates.Id = data.Id;

            var testAlbums = new List<Album>()
            {
                new Album
                {
                    Title = data.Updates.Albums.First().Title,
                    Year = data.Updates.Albums.First().Year,
                    Producer = data.Updates.Albums.First().Producer,
                    ImgLink = data.Updates.Albums.First().ImgLink
                }
            };

            this.data.Artists
                .SearchFor(x => x.ID == data.Id)
                .ToList()
                .ForEach(y =>
                {
                    y.Name = data.Updates.Name;
                    y.BirthDate = data.Updates.BirthDate;
                    y.Country = data.Updates.Country;
                    y.ImgLink = data.Updates.ImgLink;
                    y.Albums=(testAlbums);
                    //y.Albums.ToList()
                    //    .AddRange(data.Updates.Albums
                    //        .AsQueryable()
                    //        .ProjectTo<Album>());
                    this.data.Artists.Update(y);
                });

            this.data.SaveChanges();
            return this.Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete([FromBody] int id)
        {
            var artist = this.data.Artists.SearchFor(x => x.ID == id).FirstOrDefault();
            this.data.Artists.Delete(artist);

            this.data.SaveChanges();

            return this.Ok();
        }
    }
}