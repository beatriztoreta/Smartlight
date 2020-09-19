using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppTCC
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [MaxLength(20)]
        public string user { get; set; }
        [MaxLength(20)]
        public string password { get; set; }
    }
}
