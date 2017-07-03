using ServiceApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ServiceApi.Service.Dao
{
    public class ProjectDao : BaseDao
    {
        public List<BeautyItem> GetProjectList(int catId)
        {
            var sql = "select * from BeautyItem where CatID=@CatID";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter() { ParameterName = "CatID", Value = catId, SqlDbType = SqlDbType.Int });

            var dataReader = sqlHelper.ExecuteReader(CommandType.Text, sql, parameters.ToArray());

            return base.ConvertDataReaderToEntiies<BeautyItem>(dataReader);

        }

        public List<BeautyItem> GetProjectList()
        {
            var sql = "select * from BeautyItem ";

            var dataReader = sqlHelper.ExecuteReader(CommandType.Text, sql);

            return base.ConvertDataReaderToEntiies<BeautyItem>(dataReader);

        }

        public BeautyItem GetProject(long id)
        {
            var sql = "select * from BeautyItem where ID=@ID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter() { ParameterName = "ID", Value = id, SqlDbType = SqlDbType.Int });

            var dataReader = sqlHelper.ExecuteReader(CommandType.Text, sql, parameters.ToArray());
            if (dataReader.HasRows)
            {
                dataReader.Read();
                return base.ConvertDataReaderRowToEntity<BeautyItem>(dataReader);
            }
            else
            {
                return null;
            }

        }
    }
}