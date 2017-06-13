using ServiceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiceApi.Controllers
{
    public class UserController : ApiController
    {

        //GET api/user
        /// <summary>
        /// 用户 微信ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VIP Get(string id)
        {
            return new VIP();
        }
    }
}
