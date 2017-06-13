using ServiceApi.Models;
using ServiceApi.Service.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceApi.Service
{
    public class OrderService
    {
        public void CreateOrder(Order order)
        {
            if (order.BeautyItemID == 0) throw new Exception("订单走丢了，请重新选择宝贝下单。");
            OrderDao orderDao = new OrderDao();
            order.CreateDate = DateTime.Now;

            orderDao.Insert(order);
        }
    }
}