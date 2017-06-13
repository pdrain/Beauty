using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceApi.Models
{
    public class Order
    {
        public long ID { get; set; }

        public int BeautyItemID { get; set; }

        public string BeautyItemName { get; set; }

       

        /// <summary>
        /// 价格
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// 预付款
        /// </summary>
        public double Imprest { get; set; }

        public long VipID { get; set; }

        public string VipName { get; set; }

        public string Mobile { get; set; }

        public int SalesID { get; set; }

        public Nullable<DateTime> SubscribeDate { get; set; }

        public DateTime CreateDate { get; set; }

        
    }

}
