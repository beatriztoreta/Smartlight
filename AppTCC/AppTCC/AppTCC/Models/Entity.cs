using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AppTCC.Models
{
    [Table("entities")]
    public class Entity
    {
        [PrimaryKey, AutoIncrement]
        public string _id { get; set; }

        public string _entity_id { get; set; }

        public List<Obj_Sector> sectors { get; set; }

    }

    public class Obj_Sector
    {
        public int sector_tag { get; set; }

        public string sector { get; set; }

        public List<bool> status { get; set; }

        public int max_intensity { get; set; }

        public int min_intensity { get; set; }

        public List<Info_sensor> sensors { get; set; }

        public List<Info> power { get; set; }

    }

    public class Info_sensor
    {
        public int sensor_tag { get; set; }

        public int sensor_name { get; set; }

        public List<Info> presence { get; set; }

        public List<Info> light { get; set; }

    }

    public class Info
    {
        public List<int> values { get; set; }

        public int timestamp { get; set; }
    }
}
