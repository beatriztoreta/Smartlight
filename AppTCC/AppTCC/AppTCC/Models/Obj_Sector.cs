using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTCC.Models
{
    [Table("tb_sectors")]
    public class Obj_Sector
    {
        [JsonProperty("sector_tag")]
        public int sector_tag { get; set; }

        [JsonProperty("sector")]
        public string sector { get; set; }

        [JsonProperty("status")]
        public List<bool> status { get; set; }

        [JsonProperty("max_intensity")]
        public int max_intensity { get; set; }

        [JsonProperty("min_intensity")]
        public int min_intensity { get; set; }

        [JsonProperty("sensors")]
        public List<Info_sensor> sensors { get; set; }

        [JsonProperty("power")]
        public List<Info> power { get; set; }
    }
}
