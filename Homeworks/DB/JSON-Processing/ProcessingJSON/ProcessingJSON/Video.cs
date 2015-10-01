namespace ProcessingJSON
{
    using Newtonsoft.Json;

    public class Video
    {
        [JsonProperty("title")]
        public string Title { get; set; }

       [JsonProperty("link")]
        public Url Url { get; set; }

    }
}
