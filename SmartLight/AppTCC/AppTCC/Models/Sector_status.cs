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

        public string status_code_sector_text { get; set; }

        [JsonProperty("status")]
        public List<Sensor_status> status { get; set; }

    }

}
