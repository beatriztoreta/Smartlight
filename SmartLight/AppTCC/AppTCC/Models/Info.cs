using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLight.Models
{
    public class Info
    {
        [JsonProperty("values")]
        public List<int> values { get; set; }

        [JsonProperty("timestamp")]
        public long timestamp { get; set; }
    }
}
