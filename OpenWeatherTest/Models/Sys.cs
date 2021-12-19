using Newtonsoft.Json;

namespace OpenWeatherTest.Models
{
    public class Sys
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("sunrise")]
        public string Sunrise { get; set; }
        [JsonProperty("sunset")]
        public string Sunset { get; set; }
    }
}
