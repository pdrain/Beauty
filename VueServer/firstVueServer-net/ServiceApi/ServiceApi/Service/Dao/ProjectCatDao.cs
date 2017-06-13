using ServiceApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ServiceApi.Service.Dao
{
    public class ProjectCatDao:BaseDao
    {
        public List<ProjectCat> GetProjectCats()
        {
            var sql = "select * from ProjectCat order by ID";
            SqlDataReader dataReader = sqlHelper.ExecuteReader(CommandType.Text, sql);

            return base.ConvertDataReaderToEntiies<ProjectCat>(dataReader);
        }
    }
}