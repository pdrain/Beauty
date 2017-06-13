using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceApi.Models
{
    public class OrderBill
    {       

        public long ID { get; set; }

        public long OrderID { get; set; }

        public string Name { get; set; }

        public DateTime BillDate { get; set; }

        public long VipID { get; set; }

        public double Amount { get; set; }

        public string Remark { get; set; }

        public long CreateUser { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
