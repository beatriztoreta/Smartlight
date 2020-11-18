using Newtonsoft.Json;
using SQLite;

namespace SmartLight.Models
{
    [Table("tb_graphics")]
    public class Graphics_Data
    {
        [JsonProperty("min")]
        public int min { get; set; }

        [JsonProperty("max")]
        public int max { get; set; }

        [JsonProperty("timestamp")]
        public long timestamp { get; set; }
    }
}
