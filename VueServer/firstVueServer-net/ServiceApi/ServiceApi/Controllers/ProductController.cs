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
    public class ProductController : ApiController
    {

        //  api/product/{0}
        public Product Get(int id)
        {
            ProductService productService = new ProductService();
            return productService.GetProduct(id);
        }

        //  api/product/ProductList/{0}
        public IEnumerable<Product> ProductList(int catId)
        {
            ProductService productService = new ProductService();
            return productService.GetProductList(catId);
        }

        [HttpPost]
        //  api/product/Delete/{0}
        public void Delete(int id)
        {
            ProductService productService = new ProductService();


        }
    }
}
