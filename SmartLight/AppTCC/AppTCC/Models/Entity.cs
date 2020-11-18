using System.Collections.Generic;
using SQLite;
using Newtonsoft.Json;

namespace SmartLight.Models
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

        [JsonProperty("time_data")]
        public List<Graphics_Data> time_data { get; set; }
    }
   
}
