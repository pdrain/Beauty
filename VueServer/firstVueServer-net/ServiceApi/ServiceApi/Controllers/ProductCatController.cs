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
        //GET api/productcat
        public IEnumerable<ProductCat> Get()
        {
            ProductService productService = new ProductService();
            return productService.GetProductCats();
        }

        //GET api/productcat/1
        public ProductCat Get(int id)
        {
            return new ProductCat();
        }

        // POST api/productcat
        [HttpPost]
        public void Save([FromBody]string value)
        {
            ProductService productService = new ProductService();
        }



        // DELETE api/productcat/5
        [HttpPost]
        public void Delete(int id)
        {
            ProductService productService = new ProductService();
        }
    }
}
