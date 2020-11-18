using Newtonsoft.Json;
using System.Collections.Generic;

namespace SmartLight.Models
{
    public class Sector_status_aux
    {
        [JsonProperty("status_aux")]
        public List<Sector_status> status_aux { get; set; }
    }
}
