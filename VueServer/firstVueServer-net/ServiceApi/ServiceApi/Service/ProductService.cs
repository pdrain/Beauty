using ServiceApi.Models;
using ServiceApi.Service.Dao;
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
            ProductCatDao productCatDao = new ProductCatDao();
            return productCatDao.GetProductCats();
        }


        public Product GetProduct(int id)
        {
            return new Product();
        }

        public List<Product> GetProductList(int catId)
        {
            ProductDao productDao = new ProductDao();
            return productDao.GetProductList(catId);
        }
    }
}