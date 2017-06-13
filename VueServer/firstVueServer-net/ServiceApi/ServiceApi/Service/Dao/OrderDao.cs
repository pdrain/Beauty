using ServiceApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceApi.Service.Dao
{
    public class OrderDao : BaseDao
    {
        public long Insert(Order order)
        {
            string sql = @"insert into [Order] (BeautyItemID, VipID, Price, BeautyItemName, Imprest,  CreateDate, VipName, Mobile, SalesID) 
                            values  
                            (@BeautyItemID, @VipID, @Price, @BeautyItemName, @Imprest,  @CreateDate, @VipName, @Mobile, @SalesID)";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter() { ParameterName = "BeautyItemID", Value = order.BeautyItemID, SqlDbType = SqlDbType.Int });
            parameters.Add(new SqlParameter() { ParameterName = "VipID", Value = order.VipID, SqlDbType = SqlDbType.Int });
            parameters.Add(new SqlParameter() { ParameterName = "Price", Value = order.Price, SqlDbType = SqlDbType.Float });
            parameters.Add(new SqlParameter() { ParameterName = "BeautyItemName", Value = order.BeautyItemName ?? string.Empty, SqlDbType = SqlDbType.NVarChar });
            parameters.Add(new SqlParameter() { ParameterName = "Imprest", Value = order.Imprest, SqlDbType = SqlDbType.Float });
            parameters.Add(new SqlParameter() { ParameterName = "CreateDate", Value = order.CreateDate, SqlDbType = SqlDbType.DateTime });
            parameters.Add(new SqlParameter() { ParameterName = "VipName", Value = order.VipName ?? string.Empty, SqlDbType = SqlDbType.NVarChar });
            parameters.Add(new SqlParameter() { ParameterName = "Mobile", Value = order.Mobile ?? string.Empty, SqlDbType = SqlDbType.NVarChar });
            parameters.Add(new SqlParameter() { ParameterName = "SalesID", Value = order.SalesID, SqlDbType = SqlDbType.Int });


            sqlHelper.ExecuteNonQuery(CommandType.Text, sql, parameters.ToArray());

            sql = "select  top 1 ID from [Order] order by id desc";
            long orderId = (long)sqlHelper.ExecuteScalar(CommandType.Text, sql);
            return orderId;
        }

        public List<Order> GetAllOrders()
        {
            return new List<Order>();
        }

        public List<Order> GetOrdersByUserId(long userId)
        {
            return new List<Order>();
        }
    }
}
