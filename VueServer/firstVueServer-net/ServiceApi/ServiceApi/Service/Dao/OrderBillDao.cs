
using BeautyProjectModes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceApi.Service.Dao
{
    public class OrderBillDao : BaseDao
    {
        public int Insert(OrderBill orderBill)
        {
            string sql = @"insert into OrderBill (OrderID, Name, BillDate, VipID, Amount, Remark, CreateUser, CreateDate) 
                            values  
                            (@OrderID, @Name, @BillDate, @VipID, @Amount, @Remark, @CreateUser, @CreateDate)";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter() { ParameterName = "OrderID", Value = orderBill.OrderID, SqlDbType = SqlDbType.Int });
            parameters.Add(new SqlParameter() { ParameterName = "Name", Value = orderBill.Name, SqlDbType = SqlDbType.Int });
            parameters.Add(new SqlParameter() { ParameterName = "BillDate", Value = orderBill.BillDate, SqlDbType = SqlDbType.Int });
            parameters.Add(new SqlParameter() { ParameterName = "UserID", Value = orderBill.UserID, SqlDbType = SqlDbType.DateTime });
            parameters.Add(new SqlParameter() { ParameterName = "Amount", Value = orderBill.Amount, SqlDbType = SqlDbType.Float });
            parameters.Add(new SqlParameter() { ParameterName = "Remark", Value = orderBill.Remark, SqlDbType = SqlDbType.Float });
            parameters.Add(new SqlParameter() { ParameterName = "CreateUser", Value = orderBill.CreateUser, SqlDbType = SqlDbType.Int });
            parameters.Add(new SqlParameter() { ParameterName = "CreateDate", Value = orderBill.CreateDate, SqlDbType = SqlDbType.BigInt });


            sqlHelper.ExecuteNonQuery(CommandType.Text, sql, parameters.ToArray());

            sql = "select  top 1 ID from OrderBill order by id desc";
            int vipId = (int)sqlHelper.ExecuteScalar(CommandType.Text, sql);
            return vipId;
        }

        public void Update(OrderBill orderBill)
        {
            string sql = @"update OrderBill set OrderID=@OrderID, Name=@Name, BillDate=@BillDate, VipID=@VipID, 
            Amount=@Amount, Remark=@Remark, CreateUser=@CreateUser, CreateDate=@CreateDate where ID=@ID";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter() { ParameterName = "OrderID", Value = orderBill.OrderID, SqlDbType = SqlDbType.Int });
            parameters.Add(new SqlParameter() { ParameterName = "Name", Value = orderBill.Name, SqlDbType = SqlDbType.Int });
            parameters.Add(new SqlParameter() { ParameterName = "BillDate", Value = orderBill.BillDate, SqlDbType = SqlDbType.Int });
            parameters.Add(new SqlParameter() { ParameterName = "UserID", Value = orderBill.UserID, SqlDbType = SqlDbType.DateTime });
            parameters.Add(new SqlParameter() { ParameterName = "Amount", Value = orderBill.Amount, SqlDbType = SqlDbType.Float });
            parameters.Add(new SqlParameter() { ParameterName = "Remark", Value = orderBill.Remark, SqlDbType = SqlDbType.Float });
            parameters.Add(new SqlParameter() { ParameterName = "CreateUser", Value = orderBill.CreateUser, SqlDbType = SqlDbType.Int });
            parameters.Add(new SqlParameter() { ParameterName = "CreateDate", Value = orderBill.CreateDate, SqlDbType = SqlDbType.BigInt });
            parameters.Add(new SqlParameter() { ParameterName = "ID", Value = orderBill.ID, SqlDbType = SqlDbType.Int });

            sqlHelper.ExecuteNonQuery(CommandType.Text, sql, parameters.ToArray());
        }

        //public Sales GetOrderBill(int salesId)
        //{
        //    var sql = "select * from OrderBill where ID=@ID";

        //    SqlParameter[] parameters = new SqlParameter[1];
        //    parameters[0] = new SqlParameter() { ParameterName = "ID", Value = salesId, SqlDbType = SqlDbType.Int };

        //    var dataReader = sqlHelper.ExecuteReader(CommandType.Text, sql, parameters);
        //    if (dataReader.HasRows)
        //    {
        //        dataReader.Read();
        //        return base.ConvertDataReaderRowToEntity<Sales>(dataReader);
        //    }

        //    return null;
        //}

      
    }
}
