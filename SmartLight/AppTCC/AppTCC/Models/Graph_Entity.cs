﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLight.Models
{
    public class Graph_Entity
    {
        [JsonProperty("sectors")]
        public List<Graph_Sector> gra_sec { get; set; }
    }
}
