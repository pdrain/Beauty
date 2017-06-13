using ServiceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiceApi.Controllers
{
    public class ProductController : ApiController
    {
       
        public Product Get(long id)
        {
            return new Product();
        }
    }
}
