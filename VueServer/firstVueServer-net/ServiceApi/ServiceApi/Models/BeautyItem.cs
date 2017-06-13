using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceApi.Models
{
    public class BeautyItem
    {
        
        public int ID { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public double Imprest { get; set; }

        public bool IsSalesOff { get; set; }

        public double SalesOffPrice { get; set; }

        public Nullable<DateTime> SalesOffStartDate { get; set; }

        public Nullable<DateTime> SalesOffEndDate { get; set; }

        public string Description { get; set; }

        public string ShortDesc { get; set; }

        public string DisplayImage { get; set; }

        
    }
}
