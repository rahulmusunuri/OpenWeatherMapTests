using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeatherTest.Models
{
    public class WeatherResponse
    {
        [JsonProperty("coord")]
        public Coordinates Coordinates { get; set; }
        [JsonProperty("weather")]
        public List<Weather> Weather { get; set; }
        [JsonProperty("base")]
        public string Base { get; set; }
        [JsonProperty("main")]
        public Main Main { get; set; }
        [JsonProperty("visibility")]
        public string Visibility { get; set; }
        [JsonProperty("wind")]
        public Wind Wind { get; set; }
        [JsonProperty("clouds")]
        public Cloud Cloud { get; set; }
        [JsonProperty("dt")]
        public string Dt { get; set; }
        [JsonProperty("sys")]
        public Sys Sys { get; set; }
        [JsonProperty("timezone")]
        public string Timezone { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("cod")]
        public string Cod { get; set; }
    }
}
