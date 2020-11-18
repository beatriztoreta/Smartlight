using Newtonsoft.Json;

namespace SmartLight.Models
{
    public class Sensor_status
    {
        [JsonProperty("sensor_name")]
        public string sensor_name { get; set; }

        [JsonProperty("sensor_tag")]
        public int sensor_tag { get; set; }

        [JsonProperty("status_code")]
        public int status_code { get; set; }

        public string status_code_sensor_text { get; set; }
    }
}
