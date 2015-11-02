namespace WikiMusic.Services.Models
{
    using System.Collections.Generic;
    using WikiMusic.Models;

    public class UpdateAlbumSongs
    {
        public int Id { get; set; }

        public IEnumerable<SongRequestModel> Songs { get; set; } 
    }
}