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
        // POST api/order
        [HttpPost]
        public void Post([FromBody]Order value)
        {
            OrderService projectService = new OrderService();
            projectService.CreateOrder(new Order());
        }
    }
}
