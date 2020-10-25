using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace AppTCC.Models
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
