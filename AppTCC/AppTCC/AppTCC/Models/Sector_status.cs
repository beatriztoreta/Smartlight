using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLight.Models
{
    public class Sector_status
    {
        [JsonProperty("sector_tag")]
        public int sector_tag { get; set; }

        [JsonProperty("sector")]
        public string sector { get; set; }

        [JsonProperty("status_code")]
        public int status_code { get; set; }

        [JsonProperty("status")]
        public List<Sensor_status> status { get; set; }

    }

    public class Sensor_status
    {
        [JsonProperty("sensor_name")]
        public string sensor_name { get; set; }

        [JsonProperty("sensor_tag")]
        public int sensor_tag { get; set; }

        [JsonProperty("status_code")]
        public int status_code { get; set; }
    }

    public class Sector_status_aux
    {
        [JsonProperty("status_aux")]
        public List<Sector_status> status_aux { get; set; }
    }
}
