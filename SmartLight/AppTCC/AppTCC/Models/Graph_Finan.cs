using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLight.Models
{
    public class Graph_Finan
    {
        [JsonProperty("kwh_cost")]
        public double kwh_cost { get; set; }

        [JsonProperty("power")]
        public List<Info> power { get; set; }
    }
}
