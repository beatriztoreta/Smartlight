using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLight.Models
{
    public class Sector_status_aux
    {
        [JsonProperty("status_aux")]
        public List<Sector_status> status_aux { get; set; }
    }
}
