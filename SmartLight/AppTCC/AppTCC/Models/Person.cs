﻿using SQLite;
using Newtonsoft.Json;

namespace SmartLight.Models
{
    [Table("tb_users")]
    public class Person
    {
        [PrimaryKey]
        public string _id { get; set; }

        [JsonProperty("user")]
        public string user { get; set; }

        [JsonProperty("password")]
        public string password { get; set; }

        [JsonProperty("permission")]
        public string permission { get; set; }

        [JsonProperty("entity_id")]
        public string entity_id { get; set; }

        [JsonProperty("jwt")]
        public string jwt { get; set; }
    }
}
