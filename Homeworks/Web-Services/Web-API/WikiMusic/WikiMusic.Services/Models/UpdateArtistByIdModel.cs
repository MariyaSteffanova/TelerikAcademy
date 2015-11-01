namespace WikiMusic.Services.Models
{
    using System.Collections.Generic;
    using WikiMusic.Models;

    public class UpdateArtistByIdModel
    {
        public int Id { get; set; }

        public ArtistRequestModel Updates { get; set; }
    }
}