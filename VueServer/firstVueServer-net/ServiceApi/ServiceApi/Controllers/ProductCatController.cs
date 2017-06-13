using ServiceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiceApi.Controllers
{
    public class ProductCatController : ApiController
    {
        //GET api/product
        public IEnumerable<ProductCat> Get()
        {
            return new ProductCat[]{ new ProductCat(),new ProductCat()};
        }

        //GET api/product/1
        public ProductCat Get(int id)
        {
            return new ProductCat();
        }
    }
}
