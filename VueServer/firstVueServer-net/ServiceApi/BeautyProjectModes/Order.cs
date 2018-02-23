using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyProjectModes
{
    public class Order
    {
        public long ID { get; set; }

        public string SalesOpenID { get; set; }

        public int OrderStatus { get; set; }

        /// <summary>
        /// 项目ID
        /// </summary>
        public int BeautyItemID { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string BeautyItemName { get; set; }

        /// <summary>
        /// 成交价格
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// 预付款
        /// </summary>
        public double PrePay { get; set; }

        public long UserID { get; set; }

        public string UserName { get; set; }

        public string Mobile { get; set; }

        public DateTime SubscribeDate { get; set; }

        public DateTime CreateDate { get; set; }

        public Nullable<DateTime> ComfirmDate { get; set; }

        public long UpdateUser { get; set; }

        public Nullable<DateTime> UpdateDate { get; set; }

        public string Remark { get; set; }


    }

}
