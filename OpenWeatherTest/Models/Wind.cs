using Newtonsoft.Json;

namespace OpenWeatherTest.Models
{
    public class Wind
    {
        [JsonProperty("speed")]
        public string Speed { get; set; }
        [JsonProperty("deg")]
        public string Degrees { get; set; }
    }
}
