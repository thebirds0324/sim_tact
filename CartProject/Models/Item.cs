using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CartProject.Models
{
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int sector { get; set; }
    }
}
