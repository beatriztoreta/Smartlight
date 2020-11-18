using Newtonsoft.Json;
using System.Collections.Generic;

namespace SmartLight.Models
{
    public class Graph_aux
    {
        [JsonProperty("time_data")]
        public List<Graphics_Data> aux { get; set; }
    }
}
