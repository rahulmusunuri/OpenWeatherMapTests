using Newtonsoft.Json;

namespace OpenWeatherTest.Models
{
    public class Main
    {
        [JsonProperty("temp")]
        public string Temp { get; set; }
        [JsonProperty("feels_like")]
        public string Feels_Like { get; set; }
        [JsonProperty("temp_min")]
        public string Temp_Min { get; set; }
        [JsonProperty("temp_max")]
        public string Temp_Max { get; set; }
        [JsonProperty("pressure")]
        public string Pressure { get; set; }
        [JsonProperty("humidity")]
        public string Humidity { get; set; }
    }
}
