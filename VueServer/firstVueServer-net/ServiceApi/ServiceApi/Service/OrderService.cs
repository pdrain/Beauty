using BeautyProject.Dao;
using BeautyProjectModes;
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
        public ApiResult CreateOrder(Order order)
        {
            try
            {
                long userId = ApplicationContext.Current.UserId;
                if (userId == 0) throw new Exception("您还没登录，请先登录。");

                if (order.BeautyItemID == 0) throw new Exception("订单走丢了，请重新选择宝贝下单。");
                OrderDao orderDao = new OrderDao();
                order.CreateDate = DateTime.Now;
                order.OrderStatus =(int) OrderStatus.Booking;
                order.UserID = userId;
                order.SalesOpenID = ApplicationContext.Current.SalesOpenId;
                orderDao.Insert(order);
                
                return new ApiResult() { Code = 0 };
            }
            catch (Exception ex)
            {
                return new ApiResult() { Code = 0, Message = ex.Message };
            }
        }

        public ApiResult GetOrdersByUserId()
        {
            long userId = ApplicationContext.Current.UserId;
            if (userId == 0) throw new Exception("您还没登录，请先登录。");
            OrderDao orderDao = new OrderDao();
            List<Order> orders = orderDao.GetOrderByUserId(userId);

            return new ApiResult() { Code = 0, Result = orders };
        }

        public ApiResult GetOrdersBySalesId()
        {
            string openId = ApplicationContext.Current.OpenId;
            if (string.IsNullOrEmpty(openId)) throw new Exception("您还没登录，请先登录。");
            OrderDao orderDao = new OrderDao();
            List<Order> orders = orderDao.GetOrderBySalesOpenId(openId);

            return new ApiResult() { Code = 0, Result = orders };
        }

        

        public ApiResult ConfirmOrder(long orderId)
        {
            try
            {
                OrderDao orderDao = new OrderDao();
                Order order = orderDao.GetOrder(orderId);
                order.OrderStatus = (int)OrderStatus.Confirm;
                order.UpdateDate = DateTime.Now;
                order.UpdateUser = ApplicationContext.Current.UserId;
                orderDao.UpdateOrderStatus(order);

                return new ApiResult() { Code = 0 };
            }
            catch (Exception ex)
            {
                return new ApiResult() { Code = 0, Message = ex.Message };
            }
        }

        public ApiResult CancelOrder(long orderId)
        {
            try
            {
                OrderDao orderDao = new OrderDao();
                Order order = orderDao.GetOrder(orderId);
                order.OrderStatus = (int)OrderStatus.Canceled;
                order.UpdateDate = DateTime.Now;
                order.UpdateUser = ApplicationContext.Current.UserId;
                orderDao.UpdateOrderStatus(order);

                return new ApiResult() { Code = 0 };
            }
            catch (Exception ex)
            {
                return new ApiResult() { Code = 0, Message = ex.Message };
            }
        }
    }
}