using BeautyProjectModes;
using ServiceApi.Controllers.RequestBody;
using ServiceApi.Models;
using ServiceApi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiceApi.Controllers
{
    public class OrderController : ApiController
    {
        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="postdata"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult CreateOrder(CreateOrderRequestForm requestForm)
        {
            Order order = new Order();
            order.BeautyItemID = requestForm.ProjectID;
            order.BeautyItemName = requestForm.ProjectName;
            order.SubscribeDate = requestForm.SubscribeDate;
            order.UserName = requestForm.UserName;
            order.Mobile = requestForm.Mobile;

            OrderService orderService = new OrderService();
            return orderService.CreateOrder(order);
        }

        /// <summary>
        /// 获取用户订单
        /// </summary>
        /// <param name="postdata"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult GetOrdersByUserId()
        {

            OrderService orderService = new OrderService();
            return orderService.GetOrdersByUserId();
        }

        /// <summary>
        /// 获取业务员订单
        /// </summary>
        /// <param name="postdata"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult GetOrdersBySalesId()
        {

            OrderService orderService = new OrderService();
            return orderService.GetOrdersBySalesId();
        }

        /// <summary>
        /// 订单确认
        /// </summary>
        /// <param name="postdata"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult ConfirmOrder(ConfirmOrderRequestForm requestForm)
        {
            OrderService orderService = new OrderService();
            return orderService.ConfirmOrder(requestForm.OrderID);
        }

        /// <summary>
        /// 订单取消
        /// </summary>
        /// <param name="postdata"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult CancelOrder(CancelOrderRequestForm requestForm)
        {
            OrderService orderService = new OrderService();
            return orderService.CancelOrder(requestForm.OrderID);
        }
    }
}
