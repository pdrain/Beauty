using ServiceApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ServiceApi.Service.Dao
{
    public class ProjectCatDao : BaseDao
    {
        public bool Insert(ProjectCat cat)
        {
            var sql = "insert into ProjectCat ( Name, IconClass, DisplayOrder) values ( @Name, @IconClass, @DisplayOrder)";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter() { ParameterName = "Name", Value = cat.Name });
            parameters.Add(new SqlParameter() { ParameterName = "IconClass", Value = cat.IconClass });
            parameters.Add(new SqlParameter() { ParameterName = "DisplayOrder", Value = cat.DisplayOrder });


            try
            {
                int result = (int)sqlHelper.ExecuteScalar(CommandType.Text, sql, parameters.ToArray());
                if (result == 0)
                {
                    return false;
                }
                else
                {

                    return true;

                }
            }
            catch
            {
                return false;
            }

        }

        public bool Delete(int id)
        {
            var sql = "delete from   ProjectCat   where ID=@ID";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter() { ParameterName = "ID", Value = id });

            try
            {
                int result = (int)sqlHelper.ExecuteScalar(CommandType.Text, sql, parameters.ToArray());
                if (result == 0)
                {
                    return false;
                }
                else
                {

                    return true;

                }
            }
            catch
            {
                return false;
            }
        }

        public bool Update(ProjectCat cat)
        {
            var sql = "update  ProjectCat  set Name=@Name, IconClass=@IconClass, DisplayOrder=@DisplayOrder where ID=@ID";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter() { ParameterName = "Name", Value = cat.Name });
            parameters.Add(new SqlParameter() { ParameterName = "IconClass", Value = cat.IconClass });
            parameters.Add(new SqlParameter() { ParameterName = "DisplayOrder", Value = cat.DisplayOrder });
            parameters.Add(new SqlParameter() { ParameterName = "ID", Value = cat.ID });

            try
            {
                int result = (int)sqlHelper.ExecuteScalar(CommandType.Text, sql, parameters.ToArray());
                if (result == 0)
                {
                    return false;
                }
                else
                {

                    return true;

                }
            }
            catch
            {
                return false;
            }

        }

        public ProjectCat GetProjectCat(int Id)
        {
            var sql = "select * from ProjectCat where  ID=@ID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter() { ParameterName = "ID", Value = Id });
            SqlDataReader dataReader = sqlHelper.ExecuteReader(CommandType.Text, sql, parameters.ToArray());
            if (dataReader.HasRows)
            {
                dataReader.Read();
                return base.ConvertDataReaderRowToEntity<ProjectCat>(dataReader);
            }
            else
            {
                return null;
            }
        }

        public List<ProjectCat> GetProjectCats()
        {
            var sql = "select * from ProjectCat order by ID";
            SqlDataReader dataReader = sqlHelper.ExecuteReader(CommandType.Text, sql);

            return base.ConvertDataReaderToEntiies<ProjectCat>(dataReader);
        }


    }
}