using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace AppTCC.Models
{
    [Table("tb_entities")]
    public class Entity
    {
        [PrimaryKey]
        public string _id { get; set; }

        [JsonProperty("entity_id")]
        public string _entity_id { get; set; }

        [JsonProperty("sectors")]
        public List<Obj_Sector> sectors { get; set; }
        
    }

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

    public class Info
    {
        [JsonProperty("values")]
        public List<int> values { get; set; }

        [JsonProperty("timestamp")]
        public long timestamp { get; set; }
    }
}
