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

        public List<Obj_proto> presence { get; set; }
        
        public List<Obj_proto> light { get; set; }

        public List<Obj_proto> power { get; set; }
    }

    public class Obj_proto
    {
       
        public int main_tag { get; set; }

        public int sensor_tag { get; set; }

        public List<int> values { get; set; }
    }
}
