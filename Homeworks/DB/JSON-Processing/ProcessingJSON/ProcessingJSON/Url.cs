namespace ProcessingJSON
{
    using Newtonsoft.Json;

    public class Url
    {
        [JsonProperty("@href")]
        public string Href { get; set; }
    }
}