using ServiceApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ServiceApi.Service.Dao
{
    public class ProductCatDao : BaseDao
    {
        public List<ProductCat> GetProductCats()
        {
            var sql = "select * from ProductCat order by ID";
            SqlDataReader dataReader = sqlHelper.ExecuteReader(CommandType.Text, sql);

            return base.ConvertDataReaderToEntiies<ProductCat>(dataReader);
        }
    }
}