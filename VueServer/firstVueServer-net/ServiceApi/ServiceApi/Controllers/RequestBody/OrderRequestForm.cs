using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceApi.Controllers.RequestBody
{
    /// <summary>
    /// 创建订单
    /// </summary>
    public class CreateOrderRequestForm: RequestBodyForm
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string UserName { get; set; }
        public string Mobile { get; set; }
        public DateTime SubscribeDate { get; set; }
    }

  
    /// <summary>
    /// 订单确认
    /// </summary>
    public class ConfirmOrderRequestForm : RequestBodyForm
    {
        public int OrderID { get; set; }
     }
     /// <summary>
    /// 取消订单
    /// </summary>
    public class CancelOrderRequestForm : RequestBodyForm
    {
        public int OrderID { get; set; }
     }
    
}