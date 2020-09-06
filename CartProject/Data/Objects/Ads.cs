using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CartProject.Models
{

    public class Ads
    {


        [PrimaryKey, AutoIncrement, Column("AdsId")]
        public int ID { get; set; }
        public Uri Text { get; set; }
        public int Section { get; set; }
    }
}
