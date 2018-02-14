using BeautyProject.Dao.Common;
using BeautyProjectModes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BeautyProject.Dao
{
    public class OrderDao : BaseDao
    {
        public void Insert(Order order)
        {
            try
            {
                string sql = "insert into [Order] (OrderStatus, BeautyItemID, BeautyItemName, Price, PrePay, UserID, UserName, Mobile, SubscribeDate, CreateDate, ComfirmDate, Remark) " +
                             "   values " +
                             " (@OrderStatus, @BeautyItemID, @BeautyItemName, @Price, @PrePay, @UserID, @UserName, @Mobile, @SubscribeDate, @CreateDate, @ComfirmDate, @Remark)";

                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter() { ParameterName = "OrderStatus", Value = order.OrderStatus });
                parameters.Add(new SqlParameter() { ParameterName = "BeautyItemID", Value = order.BeautyItemID });
                parameters.Add(new SqlParameter() { ParameterName = "BeautyItemName", Value = order.BeautyItemName ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "Price", Value = order.Price });
                parameters.Add(new SqlParameter() { ParameterName = "PrePay", Value = order.PrePay });
                parameters.Add(new SqlParameter() { ParameterName = "UserID", Value = order.UserID });
                parameters.Add(new SqlParameter() { ParameterName = "UserName", Value = order.UserName ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "Mobile", Value = order.Mobile ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "SubscribeDate", Value = order.SubscribeDate });
                parameters.Add(new SqlParameter() { ParameterName = "CreateDate", Value = order.CreateDate });
                parameters.Add(new SqlParameter() { ParameterName = "ComfirmDate", Value = order.ComfirmDate });
                parameters.Add(new SqlParameter() { ParameterName = "Remark", Value = order.Remark });

                sqlHelper.ExecuteScalar(CommandType.Text, sql, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("创建订单失败。");
            }
        }

        public void UpdateOrderStatus(Order order)
        {
            try
            {
                string sql = "update  [Order]  set OrderStatus=@OrderStatus where ID=@ID";

                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter() { ParameterName = "OrderStatus", Value = order.OrderStatus });
                parameters.Add(new SqlParameter() { ParameterName = "UpdateDate", Value = order.UpdateDate });
                parameters.Add(new SqlParameter() { ParameterName = "UpdateUser", Value = order.UpdateUser });
                parameters.Add(new SqlParameter() { ParameterName = "ID", Value = order.ID });

                sqlHelper.ExecuteScalar(CommandType.Text, sql, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("更新订单状态失败。");
            }
        }

        public Order GetOrder(long orderId)
        {
            try
            {
                string sql = "select * from   [Order]   where ID=@ID";

                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter() { ParameterName = "ID", Value = orderId });

                SqlDataReader dataReader = sqlHelper.ExecuteReader(CommandType.Text, sql, parameters.ToArray());
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    return base.ConvertDataReaderRowToEntity<Order>(dataReader);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("查询订单失败。");
            }
        }

        public List<Order> GetOrderByUserId(long userId)
        {
            try
            {
                string sql = "select * from   [Order]   where UserID=@UserID";

                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter() { ParameterName = "UserID", Value = userId });

                SqlDataReader dataReader = sqlHelper.ExecuteReader(CommandType.Text, sql, parameters.ToArray());
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    return base.ConvertDataReaderToEntiies<Order>(dataReader);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("查询订单失败。");
            }
        }

        public List<Order> GetOrderBySalesOpenId(string userId)
        {
            try
            {
                string sql = "select * from   [Order]   where SalesOpenID=@SalesOpenID";

                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter() { ParameterName = "SalesOpenID", Value = userId });

                SqlDataReader dataReader = sqlHelper.ExecuteReader(CommandType.Text, sql, parameters.ToArray());
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    return base.ConvertDataReaderToEntiies<Order>(dataReader);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("查询订单失败。");
            }
        }

        public void InsertOrderBill(OrderBill bill)
        {

        }
        public void UpdateOrderBill(OrderBill bill)
        {

        }

        public void DeleteOrderBill(OrderBill bill)
        {

        }
    }
}
