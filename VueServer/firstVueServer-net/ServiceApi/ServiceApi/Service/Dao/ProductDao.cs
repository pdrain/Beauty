using ServiceApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ServiceApi.Service.Dao
{
    public class ProductDao:BaseDao
    {
        public List<Product> GetProductList(int catId)
        {
            var sql = "select * from Product where CatID=@CatID";
            
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter() { ParameterName = "CatID", Value = catId, SqlDbType = SqlDbType.Int });

            var dataReader = sqlHelper.ExecuteReader(CommandType.Text, sql, parameters.ToArray());

            return base.ConvertDataReaderToEntiies<Product>(dataReader);

        }

        public Product GetProduct(long id)
        {
            var sql = "select * from Product where ID=@ID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter() { ParameterName = "ID", Value = id, SqlDbType = SqlDbType.Int });

            var dataReader = sqlHelper.ExecuteReader(CommandType.Text, sql, parameters.ToArray());
            if (dataReader.HasRows)
            {
                dataReader.Read();
                return base.ConvertDataReaderRowToEntity<Product>(dataReader);
            }
            else
            {
                return null;
            }

        }
    }
}