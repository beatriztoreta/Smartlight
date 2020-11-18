using Newtonsoft.Json;
using SQLite;
using System.Collections.Generic;

namespace SmartLight.Models
{
    [Table("tb_sensors")]
    public class Info_sensor
    {
        [JsonProperty("sensor_tag")]
        public int sensor_tag { get; set; }

        [JsonProperty("sensor_name")]
        public string sensor_name { get; set; }

        [JsonProperty("presence")]
        public List<Info> presence { get; set; }

        [JsonProperty("light")]
        public List<Info> light { get; set; }
    }
}
