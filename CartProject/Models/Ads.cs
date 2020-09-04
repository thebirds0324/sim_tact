using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CartProject.Models
{
    public class Ads
    {
        [PrimaryKey, AutoIncrement]

        public int ID { get; set; }
        public string Text { get; set; }
        public int Section { get; set; }
        public byte[] Image { get; set; } //Bitmap 형식으로 이미지 저장
    }
}
