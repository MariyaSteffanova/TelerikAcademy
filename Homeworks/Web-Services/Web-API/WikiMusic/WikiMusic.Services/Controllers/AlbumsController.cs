namespace WikiMusic.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using Data;

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
    }
}