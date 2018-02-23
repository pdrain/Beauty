using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeautyProjectModes
{
    public enum OrderStatus
    {
        Booking=0,      //预约
        Confirm=1,      //订单已确认
        ReSchedule=2,   //改期
        Payed=3 ,       //已付款
        Canceled=4      //取消
    }
}
