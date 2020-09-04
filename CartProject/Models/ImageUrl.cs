using System;
using System.Collections.Generic;
using System.Text;

namespace CartProject.Models
{
    public class ImageUrl
    {
        public string Url { get;set; }
        public ImageUrl(string url)
        {
            Url = url;
        }
    }
}
