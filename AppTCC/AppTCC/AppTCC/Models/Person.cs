using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AppTCC.Models
{
    [Table("users")]
    public class Person
    {
        [PrimaryKey]
        public string _id { get; set; }

        public string user { get; set; }
                
        public string password { get; set; }

    }
}
