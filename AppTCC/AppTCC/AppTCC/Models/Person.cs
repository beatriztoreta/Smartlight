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
        [PrimaryKey, AutoIncrement]
        /*[BsonId, BsonRepresentation(BsonType.ObjectId)]*/
        public string _id { get; set; }

        /*[MaxLength(20)]
        [BsonElement("user")]*/
        public string user { get; set; }
        
        
        /*[MaxLength(20)]
        [BsonElement("password")]*/
        public string password { get; set; }

    }
}
