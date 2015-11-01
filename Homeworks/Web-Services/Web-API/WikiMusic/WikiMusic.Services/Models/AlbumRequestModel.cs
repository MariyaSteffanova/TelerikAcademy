namespace WikiMusic.Services.Models
{
    using System.Collections.Generic;
    using WikiMusic.Models;

    public class AlbumRequestModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public short Year { get; set; }

        public string Producer { get; set; }

        public string ImgLink { get; set; }

        public ICollection<SongRequestModel> Songs { get; set; }
    }
}
