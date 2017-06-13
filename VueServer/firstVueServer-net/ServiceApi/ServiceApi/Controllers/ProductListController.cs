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
    public class ProductListController : ApiController
    {
        //GET api/productlist
        public IEnumerable<Product> Get()
        {
            ProductService productService = new ProductService();
            return new Product[] { new Product(), new Product() };
        }

        //GET api/productlist/1
        public IEnumerable<Product> Get(int id)
        {
            ProductService productService = new ProductService();
            return productService.GetProductList(id);
        }

    }
}
