using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTCC.Models
{
    public class Graph_aux
    {
        [JsonProperty("time_data")]
        public List<Graphics_Data> aux { get; set; }
    }
}
