using Newtonsoft.Json;

namespace OpenWeatherTest.Models
{
    public class Cloud
    {
        [JsonProperty("all")]
        public string All { get; set; }
    }
}
