using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceApi.Models
{
    public class Product
    {
        public long ID { get; set; }

        public int CatID { get; set; }

        public string Name { get; set; }

        public string ShortDesc { get; set; }

        public string Description { get; set; }

        public int ChangePoint { get; set; }

        public double Price { get; set; }

        public string DisplayImg { get; set; }
    }
}