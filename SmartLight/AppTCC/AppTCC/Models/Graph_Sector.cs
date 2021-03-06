﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace SmartLight.Models
{
    public class Graph_Sector
    {
        [JsonProperty("time_data")]
        public List<Graphics_Data> gra_data { get; set; }

        [JsonProperty("min_intensity")]
        public int min_intensity { get; set; }

        [JsonProperty("max_intensity")]
        public int max_intensity { get; set; }
    }
}
