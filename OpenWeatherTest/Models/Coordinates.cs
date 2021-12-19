using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeatherTest.Models
{
    public class Coordinates
    {
        [JsonProperty("lon")]
        public string Longitude { get; set; }
        [JsonProperty("lat")]
        public string Latitude { get; set; }
    }
}
