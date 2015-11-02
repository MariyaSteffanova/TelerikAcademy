namespace WikiMusic.Models
{
    using System;
    using System.Collections.Generic;
    using Services.Models;

    public class ArtistRequestModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string ImgLink { get; set; }

        public DateTime BirthDate { get; set; }
        
        public ICollection<AlbumRequestModel> Albums { get; set; }
    }
}
