using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AppTCC
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public int id { get; set; }

        [MaxLength(20)]
        [BsonElement("user")]
        public string user { get; set; }
        
        
        [MaxLength(20)]
        [BsonElement("password")]
        public string password { get; set; }
    }
}
