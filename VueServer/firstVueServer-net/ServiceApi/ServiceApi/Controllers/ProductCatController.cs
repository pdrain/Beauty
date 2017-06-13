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
    public class ProductCatController : ApiController
    {
        //GET api/product
        public IEnumerable<ProductCat> Get()
        {
            ProductService productService = new ProductService();
            return productService.GetProductCats();
        }

        //GET api/product/1
        public ProductCat Get(int id)
        {
            return new ProductCat();
        }
    }
}
