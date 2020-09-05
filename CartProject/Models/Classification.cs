using System;
using System.Collections.Generic;
using System.Text;

namespace CartProject.Models
{
    public class Classification
    {
        int sector;
        List<Object> array;

        public Classification(int sector, List<Object> array)
        {
            this.sector = sector;
            this.array = array;
        }

        
    }
}
