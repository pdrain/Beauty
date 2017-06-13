using ServiceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceApi.Service
{
    public class ProductService
    {
        public ProductCat GetProductCat(int id)
        {
            return new ProductCat();
        }

        public List<ProductCat> GetProductCats()
        {
            return new List<ProductCat>() { new ProductCat(), new ProductCat() };
        }


        public Product GetProduct(int id)
        {
            return new Product();
        }

        public List<Product> GetProductList(int catId)
        {
            return new List<Product>() { new Product(), new Product() };
        }
    }
}