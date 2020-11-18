using Newtonsoft.Json;
using System.Collections.Generic;

namespace SmartLight.Models
{
    public class Graph_Entity
    {
        [JsonProperty("sectors")]
        public List<Graph_Sector> gra_sec { get; set; }
    }
}
