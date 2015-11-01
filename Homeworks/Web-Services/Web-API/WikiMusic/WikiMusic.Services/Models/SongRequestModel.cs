namespace WikiMusic.Models
{
    using Services.Models;

    public class SongRequestModel
    {
        public string Title { get; set; }

        public short Year { get; set; }

        public string Genre { get; set; }
    }
}
