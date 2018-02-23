using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyProjectModes
{
    public class OrderBill
    {       

        public long ID { get; set; }

        public long OrderID { get; set; }

        public string Name { get; set; }

        public DateTime BillDate { get; set; }

        public long UserID { get; set; }

        /// <summary>
        /// 账单金额
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// 付款方式 现金 信用卡  分期 
        /// </summary>
        public int PaymentWay { get; set; }

        public string Remark { get; set; }

        public long CreateUser { get; set; }

        public DateTime CreateDate { get; set; }

        public long UpdateUser { get; set; }

        public Nullable<DateTime> UpdateDate { get; set; }

        public bool IsDel { get; set; }
    }
}
